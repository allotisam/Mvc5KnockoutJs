using BootstrapIntro.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BootstrapIntro
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // web api configuration and services
            config.Filters.Add(new ValidationActionFilterAttribute());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}