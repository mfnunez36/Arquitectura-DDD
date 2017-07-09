using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface IPerfilServicio : IDisposable
    {
        PerfilDTO Obtener(int id);
        IEnumerable<PerfilDTO> ObtenerTodos();
        PerfilDTO Agregar(PerfilDTO entidad);
        bool Modificar(PerfilDTO entidad);
        bool Eliminar(int id);
    }
}
