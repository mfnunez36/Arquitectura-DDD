using Aplicacion.Contratos;
using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioRest.Controllers
{
    public class PerfilController : ApiController
    {
        IPerfilServicio _perfilServicio;

        public PerfilController(IPerfilServicio perfilServicio)
        {
            _perfilServicio = perfilServicio;
        }

        /*Listar*/
        // GET: api/Perfil
        public IEnumerable<PerfilDTO> GetPerfilDTO()
        {
            return _perfilServicio.ObtenerTodos().AsEnumerable();
        }


        /*Buscar Por ID*/
        // GET: api/Perfil/5        
        public PerfilDTO GetPerfilDTO(int id)
        {
            var perfilDTO = _perfilServicio.Obtener(id);

            if (perfilDTO == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return perfilDTO;
        }


        /*Listar*/
        // PUT: api/Perfil/5
        public HttpResponseMessage PutPerfilDTO(int id, PerfilDTO perfilDTO)
        {   
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != perfilDTO.perfilID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                _perfilServicio.Modificar(perfilDTO);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /*AGREGAR*/
        // POST: api/Perfil
        public HttpResponseMessage PostPerfilDTO(PerfilDTO perfilDTO)
        {
            if (ModelState.IsValid)
            {
                _perfilServicio.Agregar(perfilDTO);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, perfilDTO);
                return response;
            }else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE: api/Perfil/5
        public HttpResponseMessage DeletePerfilDTO(int id = 0)
        {
            if (id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _perfilServicio.Eliminar(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _perfilServicio.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
