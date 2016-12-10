using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    public class Database : DatabaseEntity
    {
        [Ignore]
        public string DatabaseServerIp { get; set; }

        public int ServerId { get; set; }
        public int OwnerId { get; set; }
    }
}
