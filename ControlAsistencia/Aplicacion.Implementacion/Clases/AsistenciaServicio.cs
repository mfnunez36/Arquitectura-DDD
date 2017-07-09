using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class AsistenciaServicio : IAsistenciaServicio
    {
        private IAsistenciaRepositorio _asistenciaRepositorio;

        public AsistenciaServicio(IAsistenciaRepositorio asistenciaRepositorio)
        {
            _asistenciaRepositorio = asistenciaRepositorio;
        }

        public AsistenciaDTO Agregar(AsistenciaDTO entidad)
        {
            try
            {
                var objeto = new Obra();
                Mapper.Map(entidad, objeto);
                _asistenciaRepositorio.Agregar(objeto);
                _asistenciaRepositorio.UnidadDeTrabajo.Completar();
                return Mapper.Map(objeto, entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Modificar(AsistenciaDTO entidad)
        {
            try
            {
                var objeto = _asistenciaRepositorio.Obtener(entidad.AsistenciaID);
                Mapper.Map(entidad, objeto);
                _asistenciaRepositorio.UnidadDeTrabajo.Completar();
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
                var objeto = _asistenciaRepositorio.Obtener(id);
                _asistenciaRepositorio.Eliminar(objeto);
                _asistenciaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public AsistenciaDTO Obtener(int id)
        {
            var objetoRecuperado = _asistenciaRepositorio.Obtener(id);
            return Mapper.Map<Obra, AsistenciaDTO>(objetoRecuperado);
        }

        public IEnumerable<AsistenciaDTO> ObtenerTodos()
        {
            var lista = _asistenciaRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<Obra>, IEnumerable<AsistenciaDTO>>(lista);
        }


        ~AsistenciaServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_asistenciaRepositorio != null)
                {
                    _asistenciaRepositorio.Dispose();
                    _asistenciaRepositorio = null;
                }
            }
        }
    }
}
