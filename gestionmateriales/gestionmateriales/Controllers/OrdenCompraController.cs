using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class OrdenCompraController : Controller
    {

        private readonly IOrdenCompraRepository ordenCompraRepository;

        public OrdenCompraController()
        {
            ordenCompraRepository = new OrdenCompraRepository(new OficinaTecnicaEntities());
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Editar()
        {
            return View("Editar");
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View("Agregar");
        }
        [HttpPost]
        public ActionResult Agregar(OrdenCompra aOC)
        {
            return View("Agregar");
        }
        [HttpPost]
        public ActionResult Editar(OrdenCompra aOC)
        {
            return View("Editar", aOC);
        }

        [HttpGet]
        public JsonResult getOC()
        {
            var Query1 = from oc in ordenCompraRepository.GetAll()
                         where oc.hab == true
                         select new
                         {
                             id = oc.IdOrdenCompra,
                             numInt = oc.numeroInterno,
                             numFac = oc.numeroFactura,
                             fecha = oc.fecha
                             //resp = oc.responsable.nombre,
                             //prov = oc.proveedor.nombre,
                             //items = oc.itemsOC.Count()
                         };

            //var Query2 = ordenCompraRepository.Find(x => x.hab).OrderByDescending(x => x.fecha).Select(x => new { 
            //      x.IdOrdenCompra, x.numeroInterno, x.numeroFactura, x.fecha
            //});

            return Json(new { Response = Query1 }, JsonRequestBehavior.AllowGet);
        }
    }
}