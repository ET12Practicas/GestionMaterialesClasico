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
                    db.proveedores.Add(new Proveedor
                    {
                        nombre = unProveedor.nombre,
                        cuit = unProveedor.cuit,
                        razonSocial = unProveedor.razonSocial,
                        direccion = unProveedor.direccion,
                        zona = unProveedor.zona,
                        horario = unProveedor.horario,
                        telefono = unProveedor.telefono,
                        email = unProveedor.email,
                        nombreContacto = unProveedor.nombreContacto
                    });
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
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                Proveedor nuevoProveedor = db.proveedores.Find(id);
                if (db.proveedores.Where(x => x.idProveedor != id && x.hab).Any(y => y.cuit == unProveedor.cuit))
                {
                    ViewBag.Result = 1;
                    return View("Editar", unProveedor);
                }
                try
                {
                    nuevoProveedor.nombre = unProveedor.nombre;
                    nuevoProveedor.cuit = unProveedor.cuit;
                    nuevoProveedor.razonSocial = unProveedor.razonSocial;
                    nuevoProveedor.horario = unProveedor.horario;
                    nuevoProveedor.telefono = unProveedor.telefono;
                    nuevoProveedor.nombreContacto = unProveedor.nombreContacto;
                    nuevoProveedor.direccion = unProveedor.direccion;
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            ViewBag.Result = 0;
            return View("Editar", unProveedor);
        }

        //POST: Proveedor/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult Borrar(int id)
        {
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                Proveedor proveedorSeleccionado = db.proveedores.Find(id);

                try
                {
                    proveedorSeleccionado.hab = false;
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            return RedirectToAction("Index", "Proveedor");
        }
    }
}
