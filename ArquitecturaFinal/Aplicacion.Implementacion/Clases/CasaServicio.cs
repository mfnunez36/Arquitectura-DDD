using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class CasaServicio : ICasaServicio
    {
        #region Atributos

        private ICasaRepositorio _casaRepositorio;

        #endregion

        #region Constructor

        public CasaServicio(ICasaRepositorio pCasaRepositorio)
        {
            _casaRepositorio = pCasaRepositorio;
        }

        #endregion

        #region Métodos

        public CasaDTO Obtener(int id)
        {
            var objetoRecuperado = _casaRepositorio.Obtener(id);
            return Mapper.Map<Casa, CasaDTO>(objetoRecuperado);
        }

        public IEnumerable<CasaDTO> ObtenerTodas()
        {
            var lista = _casaRepositorio.ObtenerTodas();
            return Mapper.Map<IEnumerable<Casa>, IEnumerable<CasaDTO>>(lista);
        }

        public IEnumerable<CasaDTO> BuscarPorCalle(string pDireccion)
        {
            var lista = _casaRepositorio.Buscar(x => x.Calle.ToUpper().Equals(pDireccion.ToUpper()));
            return Mapper.Map<IEnumerable<Casa>, IEnumerable<CasaDTO>>(lista);
        }

        public IEnumerable<CasaDTO> BuscarPorNumeroBaños(int pNumeroBaños)
        {
            var lista = _casaRepositorio.Buscar(x => x.NumeroBaños.Equals(pNumeroBaños));
            return Mapper.Map<IEnumerable<Casa>, IEnumerable<CasaDTO>>(lista);
        }

        public CasaDTO BuscarUnoPorCalle(string pCalle)
        {
            var objetoRecuperado = _casaRepositorio.BuscarSingleOrDefault(x => x.Calle.ToUpper().Equals(pCalle.ToUpper()));
            return Mapper.Map<Casa, CasaDTO>(objetoRecuperado);
        }

        public bool Agregar(CasaDTO entidad)
        {
            try
            {
                var _objeto = new Casa();
                Mapper.Map(entidad, _objeto);
                _casaRepositorio.Agregar(_objeto);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(CasaDTO entidad)
        {
            try
            {
                var _objeto = new Casa();
                Mapper.Map(entidad, _objeto);
                _casaRepositorio.Eliminar(_objeto);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Dispose

        ~CasaServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_casaRepositorio != null)
                {
                    _casaRepositorio.Dispose();
                    _casaRepositorio = null;
                }
            }
        }

        #endregion
    }
}
