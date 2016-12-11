using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Prototype.API.Models
{
    public class ClientSite : Site<ClientDatabase>, IOwnerfull, IServerfull
    {
        [Ignore]
        public Owner Owner { get; set; }

        [Ignore]
        public ClientServer Server { get; set; }
    }
}
