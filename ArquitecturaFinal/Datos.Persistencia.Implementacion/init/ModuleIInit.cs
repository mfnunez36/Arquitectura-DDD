using Datos.Persistencia.Core;
using Dominio.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Datos.Persistencia.Implementacion.init
{
    [Export(typeof(IModule))]
    public class ModuleIInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<IContextoUnidadDeTrabajo, ContextoPrincipal>();
            register.RegisterType<ICasaRepositorio, CasaRepositorio>();
        }
    }
}
