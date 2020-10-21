using System.Web.Http;
using WebActivatorEx;
using FootballLeague.Web;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FootballLeague.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            var documentationPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}bin\{nameof(FootballLeague)}.{nameof(Application)}.xml";

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", nameof(FootballLeague));
                        c.IncludeXmlComments(documentationPath);
                    })
                .EnableSwaggerUi();
        }
    }
}
