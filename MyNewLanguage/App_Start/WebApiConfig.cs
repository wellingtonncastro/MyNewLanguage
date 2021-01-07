
using System.Web.Http;

namespace MyNewLanguage.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        config.Routes.MapHttpRoute(
            name:"GetInLate",
            routeTemplate:"api/{controller}/{action}/",
            defaults: new {action = "Get"}
        );

        }
    }
}