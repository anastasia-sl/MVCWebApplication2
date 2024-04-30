using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MvcApplication app = new MvcApplication();
            app.ConfigureRoutes();

            app.Run();
        }
    }

    public class MvcApplication
    {
        private readonly System.Web.Routing.RouteCollection _routes;

        public MvcApplication()
        {
            _routes = new System.Web.Routing.RouteCollection();
        }

        public void ConfigureRoutes()
        {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Patient", action = "Index", id = UrlParameter.Optional }
            );
        }

        public void Run()
        {
            foreach (System.Web.Routing.RouteBase route in _routes)
            {
                RouteTable.Routes.Add(route);
            }
        }
    }
}