using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        [Authorize(Roles = "administrador, oficinatecnica, rectoria, deposito, compras")]
        [Route("/Material")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        //GET: Material/Agregar
        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [Route("/Material/Agregar")]
        [HttpGet]
        public ActionResult Agregar()
        {
            cargarProveedor();
            cargarUnidad();
            cargarTipoMaterial();
            return View("Agregar");
        }

        //POST: Material/Agregar
        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [HttpPost]
        public ActionResult Agregar(Material aMat)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            if (db.materiales.Any(x => x.codigo == aMat.codigo && x.hab))
            {
                ViewBag.Result = 1;
                cargarProveedor();
                cargarUnidad();
                cargarTipoMaterial();
                return View("Agregar", aMat);
            }
            try
            {
                Unidad u = db.unidades.Find(aMat.idUnidad);
                Proveedor p = db.proveedores.Find(aMat.idProveedor);
                TipoMaterial tm = db.tipoMaterial.Find(aMat.idTipoMaterial);

                Material m = new Material(aMat.codigo, aMat.nombre, aMat.stockActual, aMat.stockMinimo, aMat.detalle, u, p, tm);
                m.CREATED_BY = User.Identity.Name;
                m.CREATION_DATE = DateTime.Now;
                m.CREATION_IP = Request.UserHostAddress;
                m.LAST_UPDATED_BY = User.Identity.Name;
                m.LAST_UPDATED_DATE = DateTime.Now;
                m.LAST_UPDATED_IP = Request.UserHostAddress;
                db.materiales.Add(m);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            cargarProveedor();
            cargarUnidad();
            cargarTipoMaterial();
            ViewBag.Result = 0;
            return View("Agregar");
        }

        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [Route("/Material/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            Material materialSelect;
            materialSelect = db.materiales.Find(id);
            cargarProveedor(materialSelect.idProveedor);
            cargarUnidad(materialSelect.idUnidad);
            cargarTipoMaterial(materialSelect.idTipoMaterial);
            return View("Editar", materialSelect);
        }

        //POST: Material/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            Material m = db.materiales.Find(id);
            if (db.materiales.Where(x => x.idMaterial != id && x.hab).Any(y => y.codigo == m.codigo))
            {
                ViewBag.Result = 1;
                cargarProveedor(m.idProveedor);
                cargarUnidad(m.idUnidad);
                cargarTipoMaterial(m.idTipoMaterial);
                return View("Editar", m);
            }
            //try
            //{
                m.nombre = unMaterial.nombre;
                m.codigo = unMaterial.codigo;
                m.idUnidad = unMaterial.idUnidad;
                m.stockMinimo = unMaterial.stockMinimo;
                m.stockActual = unMaterial.stockActual;
                m.idProveedor = unMaterial.idProveedor;
                m.idTipoMaterial = unMaterial.idTipoMaterial;
                m.detalle = unMaterial.detalle;
                m.LAST_UPDATED_BY = User.Identity.Name;
                m.LAST_UPDATED_DATE = DateTime.Now;
                m.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            //}
            //catch
            //{
            //    return RedirectToAction("Error406", "Error");
            //}
            cargarProveedor(m.idProveedor);
            cargarUnidad(m.idUnidad);
            cargarTipoMaterial(m.idTipoMaterial);
            ViewBag.Result = 0;
            return View("Editar", m);
        }

        //POST: Material/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        public ActionResult Borrar(int id)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            Material m = db.materiales.Find(id);

            try
            {
                m.hab = false;
                m.LAST_UPDATED_BY = User.Identity.Name;
                m.LAST_UPDATED_DATE = DateTime.Now;
                m.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            return RedirectToAction("Index", "Material");
        }

        [Authorize(Roles = "administrador, oficinatecnica, compras")]
        [Route("/Material/Historial/{id}")]
        [HttpGet]
        public ActionResult Historial(int id)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            List<OrdenTrabajoAplicacion> ordenesTrabajo = db.ordenTrabajoAplicacion.Where(x => x.itemsOTA.Any(y => y.idMaterial == id)).ToList();
            var material = db.materiales.FirstOrDefault(x => x.idMaterial == id);
            ViewData["codigo"] = material.codigo;
            ViewData["nombre"] = material.nombre;
            return View("Historial", ordenesTrabajo);
        }

        private void cargarTipoMaterial(object selectedTipoMaterial = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            ViewBag.idTipoMaterial = new SelectList(db.tipoMaterial.ToList(), "idTipoMaterial", "nombre", selectedTipoMaterial);
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            ViewBag.idProveedor = new SelectList(db.proveedores.Where(x => x.hab).ToList(), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            ViewBag.idUnidad = new SelectList(db.unidades.ToList(), "idUnidad", "nombre", selectedUnidad);
        }

        [Authorize(Roles = "administrador, oficinatecnica, deposito, compras")]
        [Route("/Material/GetMaterial/{id}")]
        [HttpGet]
        public JsonResult GetMaterial(string codigo)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var material = from mat in db.materiales
                           where mat.codigo.ToUpper().Equals(codigo.ToUpper())
                           select new { mat.codigo, mat.nombre };

            return Json(new { Name = "/GetMaterial", Response = material, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, oficinatecnica, deposito, compras")]
        [Route("/Material/GetMateriales")]
        [HttpGet]
        public JsonResult GetMateriales()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var materiales = from m in db.materiales
                             where m.hab == true
                             select new { m.idMaterial, m.codigo, m.nombre, m.stockActual, m.stockMinimo, m.estado, m.detalle, unidad = m.unidad.nombre, proveedor = m.proveedor.nombre, tipoMaterial = m.tipoMaterial.nombre };

            return Json(new { Name = "/GetMateriales", Response = materiales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, oficinatecnica, deposito, compras")]
        [Route("/Material/GetMaterialesShort")]
        [HttpGet]
        public JsonResult GetMaterialesShort()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var materiales = from m in db.materiales
                             where m.hab == true
                             select new { m.idMaterial, m.codigo, m.nombre, m.stockActual };

            return Json(new { Name = "/GetMaterialesShort", Response = materiales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }
    }
}