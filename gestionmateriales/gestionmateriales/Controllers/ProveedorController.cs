using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    [Authorize(Roles = "administrador, oficinatecnica, compras")]
    [Route("/Proveedor")]
    public class ProveedorController : Controller
    {
        private IProveedorRepository proveedorRepository;

        public ProveedorController()
        {
            proveedorRepository = new ProveedorRepository(new OficinaTecnicaEntities());
        }

        [Authorize(Roles = "administrador, oficinatecnica, compras, rectoria")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View("Agregar");
        }

        [HttpPost]
        public ActionResult Agregar(Proveedor unProveedor)
        {
            if (proveedorRepository.Find(x => x.hab).Any(y => y.cuit == unProveedor.cuit))
            {
                ViewBag.Result = 1;

                return View("Agregar", unProveedor);
            }

            try
            {
                proveedorRepository.Add(new Proveedor
                {
                    nombre = unProveedor.nombre,
                    cuit = unProveedor.cuit,
                    razonSocial = unProveedor.razonSocial,
                    direccion = unProveedor.direccion,
                    zona = unProveedor.zona,
                    horario = unProveedor.horario,
                    telefono = unProveedor.telefono,
                    email = unProveedor.email,
                    nombreContacto = unProveedor.nombreContacto,
                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress
                });
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            ViewBag.Result = 0;

            return View("Agregar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var proveedor = proveedorRepository.FindById(id);

            if (proveedor == null) throw new Exception("No existe el proveedor");

            return View("Editar", proveedor);
        }

        [HttpPost]
        public ActionResult Editar(int id, Proveedor unProveedor)
        {
            Proveedor proveedor = proveedorRepository.FindById(id);

            if (proveedor == null) throw new Exception("No existe el proveedor");

            if (proveedorRepository.Find(x => x.hab).Any(y => y.cuit == unProveedor.cuit))
            {
                ViewBag.Result = 1;

                return View("Editar", unProveedor);
            }

            try
            {
                proveedor.nombre = unProveedor.nombre;

                proveedor.cuit = unProveedor.cuit;

                proveedor.razonSocial = unProveedor.razonSocial;

                proveedor.horario = unProveedor.horario;

                proveedor.telefono = unProveedor.telefono;

                proveedor.nombreContacto = unProveedor.nombreContacto;

                proveedor.direccion = unProveedor.direccion;

                proveedor.LAST_UPDATED_BY = User.Identity.Name;

                proveedor.LAST_UPDATED_DATE = DateTime.Now;

                proveedor.LAST_UPDATED_IP = Request.UserHostAddress;

                proveedorRepository.Edit(proveedor);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            ViewBag.Result = 0;

            return View("Editar", unProveedor);
        }

        public ActionResult Borrar(int id)
        {
            Proveedor proveedor = proveedorRepository.FindById(id);
            
            if (proveedor == null) throw new Exception("El proveedor no existe");

            try
            {
                proveedor.hab = false;
                
                proveedor.LAST_UPDATED_BY = User.Identity.Name;

                proveedor.LAST_UPDATED_DATE = DateTime.Now;

                proveedor.LAST_UPDATED_IP = Request.UserHostAddress;

                proveedorRepository.Remove(proveedor);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Index", "Proveedor");
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var proveedores = proveedorRepository.Find(x => x.hab)
                .Select(p => new { p.idProveedor, p.nombre, p.cuit, p.telefono, p.email });

            return Json(new { Response = proveedores }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int IdProveedor)
        {
            var proveedor = proveedorRepository.Find(x => x.hab && x.idProveedor == IdProveedor)
                .Select(p => new { p.idProveedor, p.nombre, p.cuit, p.razonSocial, p.zona, p.direccion, p.telefono, p.email, p.horario, p.nombreContacto });

            return Json(new { Response = proveedor }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLastUpdated()
        {
            var fecha = proveedorRepository.Find(x => x.hab).OrderBy(x => x.LAST_UPDATED_DATE).Take(1).Select(x => new { x.LAST_UPDATED_DATE });

            return Json(new { Response = fecha }, JsonRequestBehavior.AllowGet);
        }
    }
}
