using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.API.Models;
using Database = NPoco.Database;

namespace Prototype.API.DatabaseAccess
{
    public class NPocoAccessor
    {
        private readonly Database _db;
        private readonly Owner _defaultOwner;

        public NPocoAccessor()
        {
            _db = new Database("Database");
            _defaultOwner = _db.SingleOrDefault<Owner>("WHERE Name = @0", "Unassigned");
        }

        private static string ExtractHref(DatabaseEntity e)
        {
            return $"/{e.GetType().Name}s/{e.Id}";
        }

        public Server SaveServer(Server server)
        {
            var existing = GetEntityByName<Server>(server.Name);
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

        

        private void InsertDatabases(Server server)
        {
            foreach (var databaseName in server.Databases)
            {
                var existingDb = GetEntityByName<Models.Database>(databaseName);
                if (existingDb == null)
                {
                    _db.Save(new Models.Database()
                    {
                        Name = databaseName,
                        OwnerId = server.OwnerId,
                        ServerId = server.Id
                    });
                }
            }
        }

        private void InsertSites(Server server)
        {
            foreach (var site in server.Sites)
            {
                site.ServerId = server.Id;
                var existingSite = GetEntityByName<Site>(site.Name);
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

        private void InsertDatabaseConnections(Site site)
        {
            foreach (var db in site.Databases)
            {
                var srv = GetServerByIp(db.DatabaseServerIp);
                if (srv == null) continue; // server might not be inserted yet

                var existingDb = FindDatabaseByNameAndServerId(db.Name, srv.Id);
                if (existingDb == null) return;

                db.Href = ExtractHref(db);
                db.Id = existingDb.Id;
                db.OwnerId = existingDb.OwnerId;

                TryInsertConnection(site, existingDb);
            }
        }

        private void TryInsertConnection(Site site, Models.Database db)
        {
            var conn = new SiteToDatabase()
            {
                DatabaseId = db.Id,
                SiteId = site.Id
            };
            try
            {
                _db.Save(conn);
            }
            catch (Exception)
            {
                // already exists
            }
        }

        private Models.Database FindDatabaseByNameAndServerId(string name, int id)
        {
            return _db.FirstOrDefault<Models.Database>("WHERE Name = @0 AND ServerId = @1", name, id);
        }

        private Server GetServerByIp(string databaseServerIp)
        {
            return _db.FirstOrDefault<Server>("WHERE Ip = @0", databaseServerIp);
        }

        private T GetEntityByName<T>(string name)
        {
            return _db.FirstOrDefault<T>("WHERE Name = @0", name);
        }

        public IEnumerable<T> GetEntities<T>() where T : DatabaseEntity
        {
            var things = _db.Fetch<T>();
            foreach (var thing in things)
            {
                thing.Href = ExtractHref(thing);
            }
            return things;
        }

        public IEnumerable<int> SaveServers(IEnumerable<Server> servers)
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
            owner.Href = $"owners/{owner.Id}";
            return owner;
        }
    }
}
