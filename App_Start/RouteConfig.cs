using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LasFiszkas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Next",
                url: "Fish/Next",
                defaults: new { controller = "Fish", action = "Next" }
            );

            routes.MapRoute(
                name: "Summary",
                url: "Fish/Summary",
                defaults: new { controller = "Fish", action = "Summary" }
            );

            routes.MapRoute(
                name: "Guess",
                url: "Fish/Guess/set-{setName}",
                defaults: new { controller = "Fish", action = "Guess"}
            );

            routes.MapRoute(
                name: "Sets",
                url: "Sets/{action}",
                defaults: new { controller = "Sets", action = "AllSets" }
            );

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Main" },
                constraints: new { action = "Main" }
            );
        }
    }
}
