using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Artisaneer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Notice that this route handles deep-linking in this SPA
            routes.MapRoute(
                name: "Registration SPA",
                url: "Registration/{*catchall}",
                defaults: new { Controller = "Registration", action = "Index" });

            //routes.MapRoute(
            //  name: "Home SPA",
            //  url: "Home/{*catchall}",
            //  defaults: new { Controller = "Registration", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}