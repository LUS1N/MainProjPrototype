using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Database")]
    public class ClientDatabase : Database, IOwnerfull
    {
        [Ignore]
        public Owner Owner { get; set; }
    }
}
