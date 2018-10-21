using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    public class OrdenCompraController : Controller
    {

        private readonly IOrdenCompraRepository ordenCompraRepository;
        private readonly IProveedorRepository proveedorRepository;
        private readonly IPersonalRepository personalRepository;
        private readonly IItemOrdenCompraRepository itemOrdenCompraRepository;
        private readonly IMaterialRepository materialRepository;
        public OrdenCompraController()
        {
            OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            ordenCompraRepository = new OrdenCompraRepository(context);
            proveedorRepository = new ProveedorRepository(context);
            personalRepository = new PersonalRepository(context);
            itemOrdenCompraRepository = new ItemOrdenCompraRepository(context);
            materialRepository = new MaterialRepository(context);
        }

        // GET: OrdenCompra
        public ActionResult Index()
        {
            return View("Index");
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

            if (ordenCompraRepository.FindAll().Any(y => y.numeroInterno == aOC.numeroInterno))
            {
                ViewBag.Result = 1;
                CargarProveedor(aOC.idProveedor);
                CargarResponsable(aOC.idResponsable);
                return View("Agregar", aOC);
            }

            try
            {
                OrdenCompra oc = new OrdenCompra
                {
                    numeroInterno = aOC.numeroInterno,
                    numeroFactura = "Sin número",
                    fecha = aOC.fecha,
                    chequeNro = "Sin número",
                    total = 0,
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
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Materiales", new { id = idOC });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            OrdenCompra oc = ordenCompraRepository.FindById(id);
            CargarProveedor(oc.proveedor.idProveedor);
            CargarResponsable(oc.responsable.idPersonal);
            return View("Editar", oc);
        }

        [HttpPost]
        public ActionResult Editar(int id, OrdenCompra aOC)
        {
            int idOC = -1;

            OrdenCompra ocEdit = ordenCompraRepository.FindById(id);

            if (ordenCompraRepository.Find(x => x.IdOrdenCompra != id).Any(y => y.numeroInterno == aOC.numeroInterno))
            {
                ViewBag.Result = 1;
                CargarProveedor(aOC.idProveedor);
                CargarResponsable(aOC.idResponsable);
                return View("Editar", aOC);
            }

            try
            {
                ocEdit.numeroInterno = aOC.numeroInterno;
                ocEdit.numeroFactura = aOC.numeroFactura;
                ocEdit.fecha = aOC.fecha;
                ocEdit.chequeNro = aOC.chequeNro;
                ocEdit.total = aOC.total;
                ocEdit.proveedor = proveedorRepository.FindById(aOC.idProveedor);
                ocEdit.responsable = personalRepository.FindById(aOC.idResponsable);
                ocEdit.LAST_UPDATED_BY = User.Identity.Name;
                ocEdit.LAST_UPDATED_DATE = DateTime.Now;
                ocEdit.LAST_UPDATED_IP = Request.UserHostAddress;
                ordenCompraRepository.Edit(ocEdit);

            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            idOC = ocEdit.IdOrdenCompra;

            if (idOC < 0)
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Materiales", new { id = idOC });
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var oc = ordenCompraRepository.FindById(id);

            if (oc == null) throw new Exception("No existe la orden de compra");

            return View("Detalle", oc);
        }

        [HttpGet]
        public JsonResult Get_Detalle_ItemsOrdenCompra(int id)
        {

            var oc = ordenCompraRepository.FindOne(x => x.IdOrdenCompra == id);

            if (oc == null) throw new Exception("No existe orden de compra");

            var itemsOC = from i in oc.itemsOC
                           select new { codigo = i.material.codigo, material = i.material.nombre, cantidad = i.cantidad, precioUnitario = i.precioUnitario, subtotal = i.subtotal };

            return Json(new { Response = itemsOC }, JsonRequestBehavior.AllowGet);
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
        public ActionResult Materiales(int id)
        {
            var oc = ordenCompraRepository.FindById(id);

            if (oc == null) throw new Exception("La OC no existe");

            ViewData["idOc"] = id;
            ViewData["numeroInterno"] = oc.numeroInterno;
            ViewData["numeroFactura"] = oc.numeroFactura;
            ViewData["proveedor"] = oc.proveedor.nombre;
            ViewData["responsable"] = oc.responsable.nombre;
            ViewData["fecha"] = oc.fecha.ToShortDateString();
            ViewData["cheque"] = oc.chequeNro;

            return View("Materiales");


        }
        [HttpGet]
        public JsonResult GetMateriales(int id)
        {
            ItemOrdenCompra itemOC;

            var itemsMateriales = new List<object>();

            var oc = ordenCompraRepository.FindById(id);

            var items = itemOrdenCompraRepository.Find(x => x.ordenCompra.IdOrdenCompra == id).ToList();

            foreach (Material mat in materialRepository.Find(x => x.hab))
            {
                itemOC = items.FirstOrDefault(x => x.material.idMaterial == mat.idMaterial);

                if (itemOC != null)
                {
                    itemsMateriales.Add(new { idOC = oc.IdOrdenCompra, idMat = mat.idMaterial, codMat = mat.codigo, nomMat = mat.nombre, itemOC.cantidad, itemOC.precioUnitario, itemOC.subtotal });
                }
                else
                {
                    itemsMateriales.Add(new { idOC = oc.IdOrdenCompra, idMat = mat.idMaterial, codMat = mat.codigo, nomMat = mat.nombre, cantidad = String.Empty, precioUnitario = String.Empty, subtotal = String.Empty });
                }
                    
            }

            return Json(new { Response = itemsMateriales }, JsonRequestBehavior.AllowGet);
        }

        private ItemOrdenCompra GetItemOrdenCompra(List<ItemOrdenCompra> items, int idMaterial)
        {
            ItemOrdenCompra itemOC = items.FirstOrDefault(x => x.material.idMaterial == idMaterial);

            if (itemOC != null) throw new Exception("No existe el item de la orden de compra");

            return itemOC;
        }

        [HttpPost]
        public ActionResult AgregarItemMaterial(int id, int idMaterial, int unaCantidad, double unPrecioUnitario, double unSubtotal)
        {
            var unaOrdenCompra = ordenCompraRepository.FindOne(x => x.IdOrdenCompra == id);

            if (unaOrdenCompra == null) throw new Exception("No existe la orden de compra");

            var unMaterial = materialRepository.FindById(idMaterial);

            if (unMaterial == null) throw new Exception("No existe el material");

            try
            {
                ItemOrdenCompra itemOC = unaOrdenCompra.itemsOC.FirstOrDefault(x => x.material.idMaterial == idMaterial);

                if (itemOC != null)
                {
                    itemOC.cantidad = unaCantidad;

                    itemOC.precioUnitario = unPrecioUnitario;

                    itemOC.subtotal = unSubtotal;
                }
                else
                {
                    unaOrdenCompra.itemsOC.Add(new ItemOrdenCompra { ordenCompra = unaOrdenCompra, material = unMaterial, cantidad = unaCantidad, precioUnitario = unPrecioUnitario, subtotal = unSubtotal });
                }

                ordenCompraRepository.Edit(unaOrdenCompra);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return Json("200 ok");
        }

        [HttpGet]
        public JsonResult Get_Materiales_TotalOrdenCompra(int id)
        {
            var ordenCompra = ordenCompraRepository.FindById(id);

            if (ordenCompra == null) throw new Exception("La orden de compra no existe");

            double total = ordenCompra.itemsOC.Sum(x => x.subtotal);

            try
            {
                ordenCompra.total = total;

                ordenCompraRepository.Edit(ordenCompra);
            }
            catch
            {
                throw new Exception("No se puede asignar el total de la orden de compra");
            }

            return Json(new { Response = total }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLastUpdated()
        {
            var fecha = ordenCompraRepository.Find(x => x.hab).OrderByDescending(x => x.LAST_UPDATED_DATE).Take(1).Select(x => new { x.LAST_UPDATED_DATE });

            return Json(new { Response = fecha }, JsonRequestBehavior.AllowGet);
        }
    }
}