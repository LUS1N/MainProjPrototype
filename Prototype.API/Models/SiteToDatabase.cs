using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Site_To_Database")]
    public class SiteToDatabase
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int DatabaseId { get; set; }
    }
}
