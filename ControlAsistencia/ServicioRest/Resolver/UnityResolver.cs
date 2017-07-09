using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Web.Http.Dependencies;

namespace ServicioRest.Resolver
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer _contenedor;

        public UnityResolver(IUnityContainer contenedor)
        {
            if (contenedor == null)
            {
                throw new ArgumentNullException("Contenedor Vacio");
            }
            _contenedor = contenedor;
        }

        public IDependencyScope BeginScope()
        {
            var hijo = _contenedor.CreateChildContainer();
            return new UnityResolver(hijo);
        }

        public void Dispose()
        {
            _contenedor.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _contenedor.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _contenedor.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}