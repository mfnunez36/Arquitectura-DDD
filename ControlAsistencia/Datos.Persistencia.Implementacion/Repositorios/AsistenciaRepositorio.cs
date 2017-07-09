using Datos.Persistencia.Repositorios;
using Dominio.Core;
using Dominio.Contratos;
using Datos.Persistencia.Core;

namespace Datos.Persistencia.Implementacion
{
    public class AsistenciaRepositorio : RepositorioBase<Obra>, IAsistenciaRepositorio
    {
        public AsistenciaRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
    }
}
