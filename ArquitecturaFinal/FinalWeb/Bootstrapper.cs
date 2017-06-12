using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc5;
using Utilitarios.IoC;

namespace FinalWeb
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var contenedor = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(contenedor));
            return contenedor;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var contenedor = new UnityContainer();
            RegisterTypes(contenedor);
            return contenedor;
        }

        public static void RegisterTypes(IUnityContainer contenedor)
        {
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Aplicacion.*.dll");
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Dominio.*.dll");
            ModuleLoader.LoadContainer(contenedor, ".\\bin", "Datos.Persistencia*.dll");
        }
    }
}