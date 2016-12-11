using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.API.Models;

namespace Prototype.API.DatabaseAccess
{
    public class Repository
    {
        #region Setup 

        private NPocoAccessor _accessor;

        public Repository()
        {
            _accessor = new NPocoAccessor();
        }

        #endregion

        #region Saving

        public object SaveServer(DataCollectionServer server)
        {
            return _accessor.SaveServer(server);
        }

        public object SaveServers(IEnumerable<DataCollectionServer> servers)
        {
            return _accessor.SaveServers(servers);
        }

        public Owner SaveOwner(Owner owner)
        {
            return _accessor.SaveOwner(owner);
        }

        #endregion

        #region Fetching



        public IEnumerable<ClientServer> GetServers()
        {
            return _accessor.GetClientServers();
        }

        public ClientServer GetServer(int id)
        {
            return _accessor.GetClientServer(id);
        }

        public Owner GetOwner(int id)
        {
            return _accessor.GetEntity<Owner>(id);
        }
        public IEnumerable<Owner> GetOwners()
        {
            return _accessor.GetEntities<Owner>();
        }
        #endregion

        public IEnumerable<ClientSite> GetSites()
        {
            return _accessor.GetClientSites();
        }

        public ClientSite GetSite(int id)
        {
            return _accessor.GetClientSite(id);

        }

        public IEnumerable<ClientDatabase> GetDatabases()
        {
            return _accessor.GetClientDatabases();
        }

        public ClientDatabase GetDatabase(int id)
        {
            return _accessor.GetClientDatabase(id);
        }

        public IOwnerfull UpdateServerOwner(int ownerId, int serverId)
        {
            return _accessor.UpdateServersOwner(ownerId, serverId);
        }

        public IOwnerfull UpdateSiteOwner(int ownerId, int siteId)
        {
            return _accessor.UpdateSiteOwner(ownerId, siteId);
        }

        public Owner DeleteOwner(int id)
        {
            return _accessor.DeleteOwner(id);
        }
    }
}
