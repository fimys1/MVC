using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StomatologyMVC.App_Start
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Маршруты Web API
            //configuration.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}