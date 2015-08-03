using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Loot.Web.Startup))]

namespace Loot.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/api", apiApp =>
            {
                var apiConfig = new HttpConfiguration();
                apiConfig.MapHttpAttributeRoutes();

                apiApp.UseWebApi(apiConfig);
            });

            app.Use(ShowHelp);
        }

        private static async Task ShowHelp(IOwinContext context, Func<Task> next)
        {
            await context.Response.WriteAsync(@"
Hit /api/Loot/{playerName} with a GET request...
");
        }
    }
}
