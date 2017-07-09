using Aplicacion.Contratos;
using Dominio.Contratos;
using System;
using System.Collections.Generic;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Core;

namespace Aplicacion.Implementacion
{
    public class ObraServicio : IObraServicio
    {
        private IObraRepositorio _obraRepositorio;

        public ObraServicio(IObraRepositorio obraRepositorio)
        {
            _obraRepositorio = obraRepositorio;
        }

        public ObraDTO Agregar(ObraDTO entidad)
        {
            try
            {
                var objeto = new Obra();
                Mapper.Map(entidad, objeto);
                _obraRepositorio.Agregar(objeto);
                _obraRepositorio.UnidadDeTrabajo.Completar();
                return Mapper.Map(objeto, entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Modificar(ObraDTO entidad)
        {
            try
            {
                var objeto = _obraRepositorio.Obtener(entidad.obraID);
                Mapper.Map(entidad, objeto);
                _obraRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ~ObraServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_obraRepositorio != null)
                {
                    _obraRepositorio.Dispose();
                    _obraRepositorio = null;
                }
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var objeto = _obraRepositorio.Obtener(id);
                _obraRepositorio.Eliminar(objeto);
                _obraRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ObraDTO Obtener(int id)
        {
            var objetoRecuperado = _obraRepositorio.Obtener(id);
            return Mapper.Map<Obra, ObraDTO>(objetoRecuperado);
        }

        public IEnumerable<ObraDTO> ObtenerTodos()
        {
            var lista = _obraRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<Obra>, IEnumerable<ObraDTO>>(lista);
        }
    }
}
