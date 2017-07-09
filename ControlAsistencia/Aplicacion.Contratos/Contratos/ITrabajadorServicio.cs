using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface ITrabajadorServicio : IDisposable
    {
        TrabajadorDTO Obtener(int id);
        IEnumerable<TrabajadorDTO> ObtenerTodos();
        TrabajadorDTO Agregar(TrabajadorDTO entidad);
        bool Modificar(TrabajadorDTO entidad);
        bool Eliminar(TrabajadorDTO entidad);
    }
}
