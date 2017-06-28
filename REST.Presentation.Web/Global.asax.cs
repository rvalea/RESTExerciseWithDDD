using REST.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace UsersApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModuleConfigurator.Initialize();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
