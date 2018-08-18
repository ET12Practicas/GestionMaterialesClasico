using gestionmateriales.Models.OficinaTecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        // GET: OrdenTrabajo
        public ActionResult Index()
        {
            return View();
        }


        //[Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        //[Route("/OrdenTrabajo/GetOTs")]
        //[HttpGet]
        //public JsonResult GetOTs()
        //{
        //    var db = new OficinaTecnicaEntities();
        //    var ota = from o in db.ordenTrabajo
        //              where o.hab == true
        //              select new { id = o.idOrdenTrabajo, num = o.numero, fecha = o.fecha, turno = o.turno.nombre, nombre = o.nombre, res = o.responsable.nombre, jds = o.jefeSeccion.nombre, cant = o.itemsOTA.Count };
        //    return Json(new { Response = ota }, JsonRequestBehavior.AllowGet);
        //}
    }
}