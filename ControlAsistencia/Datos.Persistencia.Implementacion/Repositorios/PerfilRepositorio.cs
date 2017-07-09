using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorios;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    class PerfilRepositorio : RepositorioBase<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(IContextoUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo) { }
    }
}
