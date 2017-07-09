using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class TrabajadorObraServicio : ITrabajadorObraServicio
    {
        private ITrabajadorObraRepositorio _trabajadorObraRepositorio;

        public TrabajadorObraServicio(ITrabajadorObraRepositorio trabajadorObraRepositorio)
        {
            _trabajadorObraRepositorio = trabajadorObraRepositorio;
        }

        public TrabajadorObraDTO Agregar(TrabajadorObraDTO entidad)
        {
            try
            {
                var objeto = new TrabajadorObra();
                Mapper.Map(entidad, objeto);
                _trabajadorObraRepositorio.Agregar(objeto);
                _trabajadorObraRepositorio.UnidadDeTrabajo.Completar();
                return Mapper.Map(objeto, entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Modificar(TrabajadorObraDTO entidad)
        {
            try
            {
                var objeto = _trabajadorObraRepositorio.Obtener(entidad.trabajadorObraID);
                Mapper.Map(entidad, objeto);
                _trabajadorObraRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var _objeto = _trabajadorObraRepositorio.Obtener(id);
                _trabajadorObraRepositorio.Eliminar(_objeto);
                _trabajadorObraRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TrabajadorObraDTO Obtener(int id)
        {
            var objetoRecuperado = _trabajadorObraRepositorio.Obtener(id);
            return Mapper.Map<TrabajadorObra, TrabajadorObraDTO>(objetoRecuperado);
        }

        public IEnumerable<TrabajadorObraDTO> ObtenerTodos()
        {
            var lista = _trabajadorObraRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<TrabajadorObra>, IEnumerable<TrabajadorObraDTO>>(lista);
        }


        ~TrabajadorObraServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_trabajadorObraRepositorio != null)
                {
                    _trabajadorObraRepositorio.Dispose();
                    _trabajadorObraRepositorio = null;
                }
            }
        }
    }
}
