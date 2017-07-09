using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorios;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    class TrabajadorObraRepositorio : RepositorioBase<TrabajadorObra>, ITrabajadorObraRepositorio
    {
        public TrabajadorObraRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
    }
}
