using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface ITrabajadorObraServicio : IDisposable
    {
        TrabajadorObraDTO Obtener(int id);
        IEnumerable<TrabajadorObraDTO> ObtenerTodos();
        TrabajadorObraDTO Agregar(TrabajadorObraDTO entidad);
        bool Modificar(TrabajadorObraDTO entidad);
        bool Eliminar(int id);
    }
}
