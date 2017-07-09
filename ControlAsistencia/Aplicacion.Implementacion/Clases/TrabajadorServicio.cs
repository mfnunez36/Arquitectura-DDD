using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class TrabajadorServicio : ITrabajadorServicio
    {
        private ITrabajadorRepositorio _trabajadorRepositorio;

        public TrabajadorServicio(ITrabajadorRepositorio trabajadorObraRepositorio)
        {
            _trabajadorRepositorio = trabajadorObraRepositorio;
        }

        public TrabajadorDTO Agregar(TrabajadorDTO entidad)
        {
            try
            {
                var objeto = new Trabajador();
                Mapper.Map(entidad, objeto);
                _trabajadorRepositorio.Agregar(objeto);
                _trabajadorRepositorio.UnidadDeTrabajo.Completar();
                return Mapper.Map(objeto, entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Modificar(TrabajadorDTO entidad)
        {
            try
            {
                var objeto = _trabajadorRepositorio.Obtener(entidad.trabajadorID);
                Mapper.Map(entidad, objeto);
                _trabajadorRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(TrabajadorDTO entidad)
        {
            try
            {
                var objeto = new Trabajador();
                Mapper.Map(entidad, objeto);
                _trabajadorRepositorio.Eliminar(objeto);
                _trabajadorRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public TrabajadorDTO Obtener(int id)
        {
            var objetoRecuperado = _trabajadorRepositorio.Obtener(id);
            return Mapper.Map<Trabajador, TrabajadorDTO>(objetoRecuperado);
        }

        public IEnumerable<TrabajadorDTO> ObtenerTodos()
        {
            var lista = _trabajadorRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<Trabajador>, IEnumerable<TrabajadorDTO>>(lista);
        }


        ~TrabajadorServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_trabajadorRepositorio != null)
                {
                    _trabajadorRepositorio.Dispose();
                    _trabajadorRepositorio = null;
                }
            }
        }
    }
}
