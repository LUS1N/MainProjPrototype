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

        public object SaveServer(Server server)
        {
            _db.Save(server);
            return server;
        }
    }
}
