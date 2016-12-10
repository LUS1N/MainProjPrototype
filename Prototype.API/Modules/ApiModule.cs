using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Prototype.API.DatabaseAccess;

namespace Prototype.API.Modules
{
    public class ApiModule : NancyModule
    {
        Repository repository = new Repository();
        public ApiModule() : base("/")
        {
            #region GETs

            Get["/"] = _ => "API Module for Prototype application";

            #endregion
        }
        
    }
}
