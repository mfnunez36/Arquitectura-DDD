using Aplicacion.Contratos;
using Datos.Persistencia.Core;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Aplicacion.Implementacion
{
    [Export(typeof(IModule))]

    public class ModuleInit : IModule
    {
        public void Initialize(IRegisterModules register)
        {
            register.RegisterType<IContextoUnidadDeTrabajo, ContextoPrincipal>();

            register.RegisterType<IAsistenciaServicio, AsistenciaServicio>();
            register.RegisterType<IObraServicio, ObraServicio>();
            register.RegisterType<ITrabajadorObraServicio, TrabajadorObraServicio>();
            register.RegisterType<ITrabajadorServicio, TrabajadorServicio>();
            register.RegisterType<IPerfilServicio, PerfilServicio>();
        }
    }
}
