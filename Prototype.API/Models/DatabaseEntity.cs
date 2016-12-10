using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    public class DatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Ignore]
        public string Href { get; set; }
    }
}
