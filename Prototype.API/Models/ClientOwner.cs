using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Owner")]
    public class ClientOwner : DatabaseEntity
    {
        [Ignore]
        public IEnumerable<ClientServer> Servers { get; set; }
        [Ignore]
        public IEnumerable<ClientSite> Sites { get; set; }
        [Ignore]
        public IEnumerable<ClientDatabase> Databases { get; set; }
    }
}
