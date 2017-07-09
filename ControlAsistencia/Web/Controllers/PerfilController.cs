using Aplicacion.Contratos;
using Aplicacion.Core;
using Aplicacion.Implementacion;
using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PerfilController : Controller
    {

        private IPerfilServicio _perfilservicio;

        public PerfilController(IPerfilServicio perfilservicio)
        {
            _perfilservicio = perfilservicio;
        }
        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            var lista = _perfilservicio.ObtenerTodos();
            return Json(lista, JsonRequestBehavior.AllowGet);   
        }

        public ActionResult Editar(int id)
        {
            var obtenido = _perfilservicio.Obtener(id);
            if (obtenido == null)
            {
                return HttpNotFound();
            }

            return View(obtenido);
        }

        [HttpPost]
        public JsonResult Editar(int id, PerfilDTO perfilDTO)
        {
            return Json(_perfilservicio.Modificar(perfilDTO), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Agregar()
        {
            PerfilDTO perfilDTO = new PerfilDTO();
            return View(perfilDTO);
        }

        [HttpPost]
        public JsonResult Agregar(PerfilDTO perfilDTO)
        {
            return Json(_perfilservicio.Agregar(perfilDTO), JsonRequestBehavior.AllowGet);
        }
        
    }
}
