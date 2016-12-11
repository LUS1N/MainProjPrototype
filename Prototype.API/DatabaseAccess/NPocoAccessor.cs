using System;
using System.Collections.Generic;
using System.Security.Policy;
using Prototype.API.Models;
using Database = NPoco.Database;

namespace Prototype.API.DatabaseAccess
{
    public class NPocoAccessor
    {

        #region Setup

        private readonly Database _db;
        private readonly Owner _defaultOwner;

        public NPocoAccessor()
        {
            _db = new Database("Database");
            _defaultOwner = _db.SingleOrDefault<Owner>("WHERE Name = @0", "Unassigned");
        }

        #endregion

        #region Saving actions


        public DataCollectionServer SaveServer(DataCollectionServer server)
        {
            var existing = GetEntityByName<DataCollectionServer>(server.Name);
            if (existing == null)
            {
                server.OwnerId = _defaultOwner.Id;
                _db.Save(server);
            }
            else
            {
                server.OwnerId = existing.OwnerId;
                server.Id = existing.Id;
            }

            InsertDatabases(server);
            InsertSites(server);
            server.Href = ExtractHref(server);
            return server;
        }


        private void InsertDatabases(DataCollectionServer server)
        {
            foreach (var databaseName in server.Databases)
            {
                var existingDb = GetEntityByName<DataCollectionDatabase>(databaseName);
                if (existingDb == null)
                {
                    _db.Save(new ClientDatabase()
                    {
                        Name = databaseName,
                        OwnerId = server.OwnerId,
                        ServerId = server.Id
                    });
                }
            }
        }

        private void InsertSites(DataCollectionServer server)
        {
            foreach (var site in server.Sites)
            {
                site.ServerId = server.Id;
                var existingSite = GetEntityByName<DataCollectionSite>(site.Name);
                if (existingSite == null)
                {
                    site.OwnerId = server.OwnerId;
                    _db.Save(site);
                }
                else
                {
                    site.OwnerId = existingSite.OwnerId;
                    site.Id = existingSite.Id;
                }
                site.Href = ExtractHref(site);
                InsertDatabaseConnections(site);
            }
        }

        private void InsertDatabaseConnections(DataCollectionSite site)
        {
            foreach (var db in site.Databases)
            {
                var srv = GetServerByIp(db.DatabaseServerIp);
                if (srv == null) continue; // server might not be inserted yet

                var existingDb = FindDatabaseByNameAndServerId(db.Name, srv.Id);
                if (existingDb == null) continue; // db might not be inserted

                AssignDatabaseValues(db, existingDb);

                TryInsertConnection(site, existingDb);
            }
        }

        private void AssignDatabaseValues(DataCollectionDatabase db, ClientDatabase existingDb)
        {
            db.Href = ExtractHref(db, db.GetType().BaseType?.Name);
            db.Id = existingDb.Id;
            db.OwnerId = existingDb.OwnerId;
        }

        private void TryInsertConnection(DataCollectionSite site, ClientDatabase db)
        {
            var conn = new SiteToDatabase
            {
                DatabaseId = db.Id,
                SiteId = site.Id
            };
            TrySaveSTD(conn);
        }

        private void TrySaveSTD(SiteToDatabase conn)
        {
            try
            {
                _db.Save(conn);
            }
            catch (Exception)
            {
                // already exists
            }
        }

        public IEnumerable<int> SaveServers(IEnumerable<DataCollectionServer> servers)
        {
            var ids = new List<int>();
            foreach (var server in servers)
            {
                SaveServer(server);
                ids.Add(server.Id);
            }
            return ids;
        }

        public Owner SaveOwner(Owner owner)
        {
            _db.Save(owner);
            owner.Href = ExtractHref(owner);
            return owner;
        }

        #endregion

        #region Private methods

        private ClientDatabase FindDatabaseByNameAndServerId(string name, int id)
        {
            return _db.FirstOrDefault<ClientDatabase>("WHERE Name = @0 AND ServerId = @1", name, id);
        }

        private DataCollectionServer GetServerByIp(string databaseServerIp)
        {
            return _db.FirstOrDefault<DataCollectionServer>("WHERE Ip = @0", databaseServerIp);
        }

        private T GetEntityByName<T>(string name)
        {
            return _db.FirstOrDefault<T>("WHERE Name = @0", name);
        }

        #endregion



        public IEnumerable<T> GetEntities<T>() where T : DatabaseEntity
        {
            var things = _db.Fetch<T>();
            AssignHrefToItems(things);
            return things;
        }

        public T GetEntity<T>(int id) where T : DatabaseEntity
        {
            var ent = _db.FirstOrDefault<T>("WHERE Id = @0", id);
            if (ent == null) return null;
            ent.Href = ExtractHref(ent);
            return ent;
        }

        public IEnumerable<ClientServer> GetClientServers()
        {
            var servers = _db.Fetch<ClientServer>();
            foreach (var srv in servers)
            {
                AddServerValues(srv);
            }
            return servers;
        }

        public ClientServer GetClientServer(int id)
        {
            var server = _db.FirstOrDefault<ClientServer>("WHERE Id = @0", id);
            AddServerValues(server);
            return server;
        }

        private void AddServerValues(ClientServer srv)
        {
            AddOwner(srv);
            srv.Sites = GetServerChildWithOwner<ClientSite>(srv.Id);
            srv.Databases = GetServerChildWithOwner<ClientDatabase>(srv.Id);
            srv.Href = ExtractHref(srv, GetNameWithoutGenericArity(srv.GetType().BaseType));
        }

        private IEnumerable<T> GetServerChildWithOwner<T>(int serverId) where T : DatabaseEntity, IServerChild, IOwnerfull
        {
            var items = _db.Fetch<T>("WHERE ServerId = @0", serverId) ?? new List<T>();
            AssignHrefToItems(items);
            AssignOwnersToItems(items);
            return items;
        }

        private void AssignOwnersToItems(IEnumerable<IOwnerfull> enumerable)
        {
            foreach (var ownerfull in enumerable)
            {
                AddOwner(ownerfull);
            }
        }

        private void AssignHrefToItems<T>(IEnumerable<T> things) where T : DatabaseEntity
        {
            foreach (var thing in things)
            {
                thing.Href = ExtractHref(thing);
            }
        }

        private void AddOwner(IOwnerfull ownerfull)
        {
            ownerfull.Owner = GetEntity<Owner>(ownerfull.OwnerId);
        }

        #region Helpers
        private string GetNameWithoutGenericArity(Type t)
        {
            var name = t.Name;
            var index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        private string ExtractHref(DatabaseEntity e, string baseClass = "")
        {
            baseClass = baseClass.Length > 0 ? baseClass : e.GetType().Name;
            return $"/{baseClass}s/{e.Id}";
        }

        #endregion
    }
}