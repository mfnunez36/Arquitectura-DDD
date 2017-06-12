using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Core
{
    public interface IRepositorioBase<Entidad> : IDisposable
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        Entidad Obtener(int id); //Select * FROM Casa WHERE CasaID = id

        IEnumerable<Entidad> ObtenerTodas();

        IEnumerable<Entidad> Buscar(Expression<Func<Entidad, bool>> predicado);

        Entidad BuscarSingleOrDefault(Expression<Func<Entidad, bool>> predicado);

        void Agregar(Entidad entidad);

        void Eliminar(Entidad entidad);
    }
}
