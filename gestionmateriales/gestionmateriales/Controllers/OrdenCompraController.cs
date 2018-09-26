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
        private readonly IProveedorRepository proveedorRepository;
        private readonly IPersonalRepository personalRepository;
        public OrdenCompraController()
        {
            OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            ordenCompraRepository = new OrdenCompraRepository(context);
            proveedorRepository = new ProveedorRepository(context);
            personalRepository = new PersonalRepository(context);
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
            CargarProveedor();
            CargarResponsable();
            return View("Agregar");
        }
        [HttpPost]
        public ActionResult Agregar(OrdenCompra aOC)
        {
            int idOC = -1;

            try
            {
                OrdenCompra oc = new OrdenCompra
                {
                    numeroInterno = aOC.numeroInterno,
                    numeroFactura = aOC.numeroFactura,
                    fecha = aOC.fecha,
                    chequeNro = aOC.chequeNro,
                    total = aOC.total,
                    proveedor = proveedorRepository.FindById(aOC.idProveedor),
                    responsable = personalRepository.FindById(aOC.idResponsable),
                    hab = true,
                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress
                };

                ordenCompraRepository.Add(oc);

                idOC = ordenCompraRepository.FindOne(x => x.numeroInterno == aOC.numeroInterno).IdOrdenCompra;
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Materiales", new { id = idOC });
        }

        [HttpPost]
        public ActionResult Editar(OrdenCompra aOC)
        {
            return View("Editar", aOC);
        }

        //[HttpGet]
        //public JsonResult GetAll()
        //{
        //    OficinaTecnicaEntities db = new OficinaTecnicaEntities();

        //    var Query1 = from oc in db.ordenCompra
        //                 where oc.hab == true
        //                 select new
        //                 {
        //                     id = oc.IdOrdenCompra,
        //                     numInt = oc.numeroInterno,
        //                     numFac = oc.numeroFactura,
        //                     fecha = oc.fecha,
        //                     resp = oc.responsable.nombre,
        //                     prov = oc.proveedor.nombre,
        //                     items = oc.itemsOC.Count()
        //                 };

        //    //var Query2 = ordenCompraRepository.Find(x => x.hab).OrderByDescending(x => x.fecha).Select(x => new
        //    //{
        //    //    x.IdOrdenCompra,
        //    //    x.numeroInterno,
        //    //    x.numeroFactura,
        //    //    x.fecha
        //    //});

        //    return Json(new { Response = Query1 }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetOC(int id)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var Query2 = from oc in db.ordenCompra
                         where oc.hab == true && oc.IdOrdenCompra == id
                         select new
                         {
                             id = oc.IdOrdenCompra,
                             numInt = oc.numeroInterno,
                             numFac = oc.numeroFactura,
                             fecha = oc.fecha,
                             resp = oc.responsable.nombre,
                             prov = oc.proveedor.nombre,
                             items = oc.itemsOC.Count()
                         };

            OrdenCompra unaOrdenCompra = db.ordenCompra
                .Where(x => x.hab == true && x.IdOrdenCompra == id)
                //.Include(x => x.responsable)
                //.Include(x => x.proveedor)
                .FirstOrDefault();

            return Json(new { Response = Query2 }, JsonRequestBehavior.AllowGet);

        }
        private void CargarProveedor(object selectedProveedor = null)
        {
            ViewBag.idProveedor = new SelectList(proveedorRepository.Find(x => x.hab), "idProveedor", "nombre", selectedProveedor);
        }

        private void CargarResponsable(object selectedResponsable = null)
        {
            ViewBag.idResponsable = new SelectList(personalRepository.Find(x => x.hab), "idPersonal", "nombre", selectedResponsable);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var otas = from o in ordenCompraRepository.FindAll()
                       where o.hab == true
                       select new { o.IdOrdenCompra, o.numeroInterno, o.numeroFactura, o.fecha, responsable = o.responsable.nombre, proveedor = o.proveedor.nombre, cant = o.itemsOC.Count };

            return Json(new { Response = otas }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Materiales (int id)
        {
            var oc = ordenCompraRepository.FindById(id);
            if (oc == null) throw new Exception("La OC no existe");

            ViewData["idOc"] = id;
            ViewData["numeroInterno"] = oc.numeroInterno;
            ViewData["numeroFactura"] = oc.numeroFactura;

            return View("Materiales");
            
           
        }
    }
}