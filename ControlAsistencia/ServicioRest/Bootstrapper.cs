using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Utilitarios.IoC;

namespace ServicioRest
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var contenedor = BuildUnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(contenedor));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(contenedor);
            return contenedor;
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var contenedor = new UnityContainer();
            RegisterTypes(contenedor);
            return contenedor;
        }

        public static void RegisterTypes(IUnityContainer contenedor)
        {
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Aplicacion.*.dll");
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Dominio.*.dll");
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Datos.Persistencia.*.dll");
        }
    }
}