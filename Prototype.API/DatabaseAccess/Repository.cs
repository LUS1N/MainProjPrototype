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
        private NPocoAccessor _accessor;

        public Repository()
        {
            _accessor = new NPocoAccessor();
        }

        public object SaveServer(Server server)
        {
            return _accessor.SaveServer(server);
        }
    }
}
