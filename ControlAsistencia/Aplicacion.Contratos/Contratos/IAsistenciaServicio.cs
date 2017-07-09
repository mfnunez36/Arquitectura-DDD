using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface IAsistenciaServicio : IDisposable
    {
        AsistenciaDTO Obtener(int id);
        IEnumerable<AsistenciaDTO> ObtenerTodos();
        AsistenciaDTO Agregar(AsistenciaDTO entidad);
        bool Modificar(AsistenciaDTO entidad);
        bool Eliminar(int id);
    }
}
