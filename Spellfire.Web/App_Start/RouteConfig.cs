using System.Web.Mvc;
using System.Web.Routing;

namespace Spellfire.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Spellfire",
                url: "Spellfire/{controller}/{action}/{id}",
                defaults: new { controller = "Card", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "NotFound",
                "NotFound/{action}/{id}",
                new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
            );
        }
    }
}
