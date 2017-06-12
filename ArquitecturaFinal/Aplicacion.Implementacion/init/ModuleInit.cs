using Aplicacion.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Aplicacion.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleIInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<ICasaServicio, CasaServicio>();
        }
    }
}