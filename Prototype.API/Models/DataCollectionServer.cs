using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    [TableName("Server")]
    public class DataCollectionServer : Server<string, DataCollectionSite>
    {
        
    }
}
