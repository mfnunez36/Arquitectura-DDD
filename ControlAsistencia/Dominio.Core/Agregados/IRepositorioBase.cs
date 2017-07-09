using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Core
{
    public interface IRepositorioBase<Entidad> : IDisposable
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        Entidad Obtener(int id);
        IEnumerable<Entidad> ObtenerTodos();
        IEnumerable<Entidad> Buscar(Expression<Func<Entidad, bool>> predicado);
        void Agregar(Entidad entidad);
        void Eliminar(Entidad entidad);
    }
}
