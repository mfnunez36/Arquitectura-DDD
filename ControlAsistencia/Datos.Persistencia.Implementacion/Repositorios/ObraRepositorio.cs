using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorios;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    public class ObraRepositorio : RepositorioBase<Obra>, IObraRepositorio
    {
        public ObraRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
    }
}
