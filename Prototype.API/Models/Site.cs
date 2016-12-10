using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    public class Site : DatabaseEntity
    {
        [Ignore]
        public IEnumerable<Database> Databases { get; set; }
        public int ServerId { get; set; }
        public int OwnerId { get; set; }
    }
}
