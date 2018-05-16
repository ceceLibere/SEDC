﻿using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Students", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
