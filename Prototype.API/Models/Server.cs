using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Server")]
    public class Server : DatabaseEntity
    {
        public string Ip { get; set; }
        public string Os { get; set; }
        public int OwnerId { get; set; }
        [Ignore]
        public IEnumerable<Site> Sites { get; set; }
        [Ignore]
        public IEnumerable<string> Databases { get; set; }
    }
}
