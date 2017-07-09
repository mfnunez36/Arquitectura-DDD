using System;
using System.Collections.Generic;
using System.Linq;
using Datos.Persistencia.Core;
using Dominio.Core;
using System.Linq.Expressions;

namespace Datos.Persistencia.Repositorios
{
    public class RepositorioBase<Entidad> : IRepositorioBase<Entidad> where Entidad : class
    {
        readonly IContextoUnidadDeTrabajo _unidadDeTrabajo;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get { return _unidadDeTrabajo; }
        }

        public RepositorioBase(IContextoUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public Entidad Obtener(int id)
        {
            return _unidadDeTrabajo.Set<Entidad>().Find(id);
        }

        public IEnumerable<Entidad> ObtenerTodos()
        {
            return _unidadDeTrabajo.Set<Entidad>().AsEnumerable();
        }

        public IEnumerable<Entidad> Buscar(Expression<Func<Entidad, bool>> predicado)
        {
            return _unidadDeTrabajo.Set<Entidad>().Where(predicado);
        }

        public void Agregar(Entidad entidad)
        {
            _unidadDeTrabajo.Set<Entidad>().Add(entidad);
        }

        public void Eliminar(Entidad entidad)
        {
            _unidadDeTrabajo.Set<Entidad>().Remove(entidad);
        }

        public void Dispose()
        {
            _unidadDeTrabajo.Dispose();
        }

    }
}
