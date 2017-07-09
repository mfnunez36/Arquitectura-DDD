using ServicioRest.Resolver;
using System.Web.Http;
using Utilitarios.IoC;

namespace ServicioRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var unityContainer = Bootstrapper.Initialize();
            config.DependencyResolver = new UnityResolver(unityContainer);
            MapperInitializer.ConfigurarMapeos();

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
