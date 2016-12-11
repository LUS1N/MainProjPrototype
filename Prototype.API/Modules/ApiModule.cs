using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using Prototype.API.DatabaseAccess;
using Prototype.API.Models;
using StructureMap.Building;

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

            Get["/databases/{id?}"] = parameters => CheckIfFound(parameters.id == null ? _repository.GetDatabases() : _repository.GetDatabase(parameters.id));

            #endregion

            #region POST

            Post["/server"] = model => Response.AsJson(_repository.SaveServer(this.Bind<DataCollectionServer>()));

            Post["/owner"] = model => Response.AsJson(_repository.SaveOwner(this.Bind<Owner>()));

            #endregion

            #region PATCH

            Patch["/server/{id}"] = model => CheckIfAllowed(_repository.UpdateServerOwner(this.Bind<OwnerIDD>().OwnerId, model.id));

            Patch["/site/{id}"] = model => CheckIfAllowed(_repository.UpdateSiteOwner(this.Bind<OwnerIDD>().OwnerId, model.id));

            Patch["/owner/{id}"] = model => Response.AsJson("Not implemented");

            #endregion

            #region DELETE

            Delete["/owner/{id}"] = model => CheckIfFound(_repository.DeleteOwner(model.id));

            #endregion

            #region Testing

            // For testing, no real world scenario for this
            Post["/servers"] = model => Response.AsJson(_repository.SaveServers(this.Bind<IEnumerable<DataCollectionServer>>()));

            #endregion
        }

        class OwnerIDD
        {
            public int OwnerId { get; set; }
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

        private Response CheckIfAllowed(object o)
        {
            Response rsp;
            if (o == null)
            {
                rsp = Nancy.Response.NoBody;
                rsp.StatusCode = HttpStatusCode.Forbidden;
            }
            else
            {
                rsp = Response.AsJson(o);
            }
            return rsp;
        }
    }
}
