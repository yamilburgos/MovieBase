using System.Web.Mvc;
using System.Web.Routing;

namespace MovieBase {
    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

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