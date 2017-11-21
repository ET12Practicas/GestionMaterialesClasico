using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class ComprasController : Controller
    {
        // GET: Compras
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [Route("/Compras")]
        [HttpGet]
        public ActionResult Index()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            List<Material> materiales = db.materiales.Where(x => x.hab && x.stockActual <= x.stockMinimo).ToList();
            return View("Index", materiales);
        }
    }
}