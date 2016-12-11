using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Database")]
    public class DataCollectionDatabase : Database
    {
        [Ignore]
        public string DatabaseServerIp { get; set; }
    }
}
