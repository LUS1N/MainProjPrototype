using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Site")]
    public class Site<D> : DatabaseEntity, IServerChild, IOwnerIdd
    {
        public int ServerId { get; set; }
        public int OwnerId { get; set; }
        public Site()
        {
            Databases = new List<D>();
        }

        [Ignore]
        public IEnumerable<D> Databases { get; set; }
     
    }
}
