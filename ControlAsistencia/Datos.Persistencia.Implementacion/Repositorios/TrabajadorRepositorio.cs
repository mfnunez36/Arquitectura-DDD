using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorios;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    class TrabajadorRepositorio : RepositorioBase<Trabajador>, ITrabajadorRepositorio
    {
        public TrabajadorRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
    }
}
