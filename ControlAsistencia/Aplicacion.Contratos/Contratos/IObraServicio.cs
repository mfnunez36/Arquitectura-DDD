using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface IObraServicio : IDisposable
    {
        ObraDTO Obtener(int id);
        IEnumerable<ObraDTO> ObtenerTodos();
        ObraDTO Agregar(ObraDTO entidad);
        bool Modificar(ObraDTO entidad);
        bool Eliminar(int id);
    }
}
