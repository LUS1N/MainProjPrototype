using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using Prototype.API.DatabaseAccess;
using Prototype.API.Models;

namespace Prototype.API.Modules
{
    public class ApiModule : NancyModule
    {
        Repository repository = new Repository();
        public ApiModule() : base("/")
        {
            #region GETs

            Get["/"] = _ => "API Module for Prototype application";

            Get["/owners"] = _ => Response.AsJson(repository.GetOwners());

            Get["/servers"] = _ => Response.AsJson(repository.GetOwners());

            Get["/sites"] = _ => Response.AsJson(repository.GetOwners());

            Get["/databases"] = _ => Response.AsJson(repository.GetOwners());

            #endregion

            #region POSTs

            Post["/server"] = model => Response.AsJson(repository.SaveServer(this.Bind<Server>()));

            Post["/servers"] = model => Response.AsJson(repository.SaveServers(this.Bind<ServersBind>().Servers));

            #endregion
        }

        class ServersBind
        {
            public IEnumerable<Server> Servers { get; set; }
        }
    }
}
