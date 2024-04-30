using System;
using System.Web.Mvc;
using Owin;
using Microsoft.Owin.Hosting;
using System.Web.Routing;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://localhost:8000";

            using (WebApp.Start(url, Configuration))
            {
                Console.WriteLine($"Server running at {url}");
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
            }
        }

        public static void Configuration(IAppBuilder app)
        {
            ConfigureMvc(app);
        }

        private static void ConfigureMvc(IAppBuilder app)
        {
            var routes = RouteTable.Routes;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Patient", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}