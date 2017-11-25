using System.Web.Mvc;
using System.Web.Routing;

namespace MovieBase {
    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // An added path that gets checked first before using the default
            // route. i.e. most specific to the most generic.
            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate" },
                constraints: new { year = @"\d{4}", month = @"\d{2}"}
                // Constraining to a specific amount is @"2015|2016".
            );

            // If the url doesn't have an controller or action path provided,
            // use the defaults. to set up the path (i.e Home/Index).
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}