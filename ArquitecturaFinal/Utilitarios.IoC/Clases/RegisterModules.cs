using Microsoft.Practices.Unity;

namespace Utilitarios.IoC
{
    internal class RegisterModules : IRegisterModules
    {
        private readonly IUnityContainer _contenedor;

        public RegisterModules(IUnityContainer contenedor)
        {
            _contenedor = contenedor;
        }

        public void RegisterType<TFrom, TTo>(bool withIterception = false) where TTo : TFrom
        {
            if (!withIterception)
            {
                _contenedor.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithLifeTime<TFrom, TTo>(bool withIterception = false) where TTo : TFrom
        {
            _contenedor.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
