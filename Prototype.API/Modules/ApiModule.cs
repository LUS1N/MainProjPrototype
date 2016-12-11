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
        readonly Repository _repository = new Repository();

        public ApiModule() : base("/")
        {
            #region GET

            Get["/"] = _ => "API Module for Prototype application";

            Get["/owners/{id?}"] = parameters => CheckIfFound(parameters.id == null ? _repository.GetOwners() : _repository.GetOwner(parameters.id));

            Get["/servers/{id?}"] = parameters => CheckIfFound(parameters.id == null ? _repository.GetServers() : _repository.GetServer(parameters.id));

            Get["/sites/{id?}"] = parameters => CheckIfFound(parameters.id == null ? _repository.GetSites() : _repository.GetSite(parameters.id));

            Get["/databases/{id?}"] = parameters => Response.AsJson(_repository.GetOwners());

            #endregion

            #region POST

            Post["/server"] = model => Response.AsJson(_repository.SaveServer(this.Bind<DataCollectionServer>()));

            Post["/owner"] = model => Response.AsJson(_repository.SaveOwner(this.Bind<Owner>()));

            #endregion

            #region PATCH

            Patch["/server/{id}"] = model => Response.AsJson("Not implemented");

            Patch["/site/{id}"] = model => Response.AsJson("Not implemented");

            Patch["/owner/{id}"] = model => Response.AsJson("Not implemented");

            #endregion

            #region DELETE

            Delete["/owner/{id}"] = model => Response.AsJson("Not implemented");

            #endregion

            #region Testing

            // For testing, no real world scenario for this
            Post["/servers"] = model => Response.AsJson(_repository.SaveServers(this.Bind<IEnumerable<DataCollectionServer>>()));

            #endregion
        }

        private Response CheckIfFound(object o)
        {
            Response rsp;
            if (o == null)
            {
                rsp = Nancy.Response.NoBody;
                rsp.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                rsp = Response.AsJson(o);
            }
            return rsp;
        }
    }
}
