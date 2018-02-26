using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;


namespace gestionmateriales.Controllers
{
    public class ProveedorController : Controller
    {        
        // GET: Proveedor
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [Route("/Proveedor")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [Route("/Proveedor/GetProveedores")]
        [HttpGet]
        public JsonResult GetProveedores()
        {
            var db = new OficinaTecnicaEntities();
            var proveedores = from p in db.proveedores
                              where p.hab == true
                              select new { p.idProveedor, p.nombre, p.cuit, p.razonSocial, p.zona, p.direccion, p.telefono, p.email, p.horario, p.nombreContacto };

            return Json(new { Name = "/GetProveedores", Response = proveedores, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Proveedor/Agregar")]
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: Proveedor/1/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Agregar(Proveedor unProveedor)
        {
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                if (db.proveedores.Any(y => y.cuit == unProveedor.cuit && y.hab))
                {
                    ViewBag.Result = 1;
                    return View("Agregar", unProveedor);
                }
                try
                {
                    var p = new Proveedor();
                    p.nombre = unProveedor.nombre;
                    p.cuit = unProveedor.cuit;
                    p.razonSocial = unProveedor.razonSocial;
                    p.direccion = unProveedor.direccion;
                    p.zona = unProveedor.zona;
                    p.horario = unProveedor.horario;
                    p.telefono = unProveedor.telefono;
                    p.email = unProveedor.email;
                    p.nombreContacto = unProveedor.nombreContacto;
                    p.CREATED_BY = User.Identity.Name;
                    p.CREATION_DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                    p.CREATION_IP = Request.UserHostAddress;
                    p.LAST_UPDATED_BY = User.Identity.Name;
                    p.LAST_UPDATED_DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                    p.LAST_UPDATED_IP = Request.UserHostAddress;
                    db.proveedores.Add(p);
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            ViewBag.Result = 0;
            return View("Agregar");
        }

        //GET: Proveedor/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Proveedor/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Proveedor unProveedor;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                try
                {
                    unProveedor = db.proveedores.Find(id);
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            return View(unProveedor);
        }

        //POST: Proveedor/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, Proveedor unProveedor)
        {
            var db = new OficinaTecnicaEntities();
            Proveedor p = db.proveedores.Find(id);
            if (db.proveedores.Where(x => x.idProveedor != id && x.hab).Any(y => y.cuit == unProveedor.cuit))
            {
                ViewBag.Result = 1;
                return View("Editar", unProveedor);
            }
            try
            {
                p.nombre = unProveedor.nombre;
                p.cuit = unProveedor.cuit;
                p.razonSocial = unProveedor.razonSocial;
                p.horario = unProveedor.horario;
                p.telefono = unProveedor.telefono;
                p.nombreContacto = unProveedor.nombreContacto;
                p.direccion = unProveedor.direccion;
                p.LAST_UPDATED_BY = User.Identity.Name;
                p.LAST_UPDATED_DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                p.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            ViewBag.Result = 0;
            return View("Editar", unProveedor);
        }

        //POST: Proveedor/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult Borrar(int id)
        {
            var db = new OficinaTecnicaEntities();
            Proveedor p = db.proveedores.Find(id);

            try
            {
                p.hab = false;
                p.LAST_UPDATED_BY = User.Identity.Name;
                p.LAST_UPDATED_DATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                p.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            return RedirectToAction("Index", "Proveedor");
        }
    }
}
