using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Server")]
    public class Server<D, S> : DatabaseEntity, IOwnerIdd
    {
        public string Ip { get; set; }
        public string Os { get; set; }
        public int OwnerId { get; set; }

        [Ignore]
        public IEnumerable<S> Sites { get; set; }
        [Ignore]
        public IEnumerable<D> Databases { get; set; }
    }
}
