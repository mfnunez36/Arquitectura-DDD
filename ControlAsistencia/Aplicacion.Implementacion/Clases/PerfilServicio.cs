using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class PerfilServicio : IPerfilServicio
    {
        private IPerfilRepositorio _perfilRepositorio;

        public PerfilServicio(IPerfilRepositorio perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }

        public PerfilDTO Agregar(PerfilDTO entidad)
        {
            try
            {
                var objeto = new Perfil();
                Mapper.Map(entidad, objeto);
                _perfilRepositorio.Agregar(objeto);
                _perfilRepositorio.UnidadDeTrabajo.Completar();
                return Mapper.Map(objeto, entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Modificar(PerfilDTO entidad)
        {
            try
            {
                var objeto = _perfilRepositorio.Obtener(entidad.perfilID);
                Mapper.Map(entidad, objeto);
                _perfilRepositorio.UnidadDeTrabajo.Completar();
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
                var objeto = _perfilRepositorio.Obtener(id);
                _perfilRepositorio.Eliminar(objeto);
                _perfilRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public PerfilDTO Obtener(int id)
        {
            var objetoRecuperado = _perfilRepositorio.Obtener(id);
            return Mapper.Map<Perfil, PerfilDTO>(objetoRecuperado);
        }

        public IEnumerable<PerfilDTO> ObtenerTodos()
        {
            var lista = _perfilRepositorio.ObtenerTodos();
            return Mapper.Map<IEnumerable<Perfil>, IEnumerable<PerfilDTO>>(lista);
        }


        ~PerfilServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_perfilRepositorio != null)
                {
                    _perfilRepositorio.Dispose();
                    _perfilRepositorio = null;
                }
            }
        }
    }
}
