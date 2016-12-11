using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.API.Models
{
    public interface IOwnerfull : IOwnerIdd
    {
        Owner Owner { get; set; }
    }
}
