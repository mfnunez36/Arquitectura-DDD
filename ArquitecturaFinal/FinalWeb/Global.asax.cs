using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Utilitarios.IoC;

namespace FinalWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var unityContainer = Bootstrapper.Initialize();
            ModuleLoader.LoadContainer(unityContainer, ".\\bin", "Datos.Persistencia.Implementacion.dll");
            ModuleLoader.LoadContainer(unityContainer, ".\\bin", "Aplicacion.Implementacion.dll");
            MapperInitializer.ConfigurarMapeos();
        }
    }
}
