using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;
using gestionmateriales.Models;

namespace gestionmateriales.Controllers
{
    public class ComprasController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();

        // GET: Compras
        [Authorize(Roles = "administrador, oficinatecnica, compras, rectoria")]
        [Route("/Compras")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [HttpGet]
        public JsonResult GetCompras()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var materiales = from m in db.materiales
                             where m.hab == true && m.stockActual <= m.stockMinimo
                             select new { m.codigo, m.nombre, m.stockActual, m.stockMinimo, m.estado, proveedor = m.proveedor.nombre };
            return Json(new { Name = "/GetCompras", Response = materiales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [HttpGet]
        public JsonResult GetCantidadCompras()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            int cantidad = db.materiales.Where(x => x.hab == true && x.stockActual <= x.stockMinimo).Count();
            return Json(new { Name = "/GetCantidadCompras", Response = cantidad, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }
    }
}