using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();
        
        // GET: Material
        [Authorize(Roles = "administrador, oficinatecnica, rectoria, deposito")]
        [Route("/Material")]
        [HttpGet]
        public ActionResult Index()
        {
            List<Material> materiales = db.materiales.Where(x => x.hab).ToList();
            return View(materiales);
        }

        //GET: Material/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
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
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Agregar(Material aMat)
        {
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
                db.materiales.Add(new Material(aMat.codigo, aMat.nombre, aMat.stockActual, aMat.stockMinimo, aMat.detalle, u, p, tm));
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

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Material/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Material materialSelect;
            materialSelect = db.materiales.Find(id);
            cargarProveedor(materialSelect.idProveedor);
            cargarUnidad(materialSelect.idUnidad);
            cargarTipoMaterial(materialSelect.idTipoMaterial);
            return View(materialSelect);
        }
      
        //POST: Material/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            Material materialEdit = db.materiales.Find(id);
            if (db.materiales.Where(x => x.idMaterial != id && x.hab).Any(y => y.codigo == materialEdit.codigo))
            {
                ViewBag.Result = 1;
                cargarProveedor(materialEdit.idProveedor);
                cargarUnidad(materialEdit.idUnidad);
                cargarTipoMaterial(materialEdit.idTipoMaterial);
                return View("Editar", materialEdit);
            }
            try
            {
                materialEdit.nombre = unMaterial.nombre;
                materialEdit.codigo = unMaterial.codigo;
                materialEdit.idUnidad = unMaterial.idUnidad;
                materialEdit.stockMinimo = unMaterial.stockMinimo;
                materialEdit.stockActual = unMaterial.stockActual;
                materialEdit.idProveedor = unMaterial.idProveedor; ;
                materialEdit.idTipoMaterial = unMaterial.idTipoMaterial;
                materialEdit.detalle = unMaterial.detalle;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            cargarProveedor(materialEdit.idProveedor);
            cargarUnidad(materialEdit.idUnidad);
            cargarTipoMaterial(materialEdit.idTipoMaterial);
            ViewBag.Result = 0;
            return View("Editar", materialEdit);
        }
        
        //POST: Material/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult Borrar(int id)
        {
            Material nuevoMaterial = db.materiales.Find(id);

            try
            {
                nuevoMaterial.hab = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            return RedirectToAction("Index", "Material");
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Material/Historial/{id}")]
        [HttpGet]
        public ActionResult Historial(int id)
        {
            List<OrdenTrabajo> ordenesTrabajo = db.ordenTrabajo.Where(x => x.itemsOT.Any(y => y.idMaterial == id)).ToList();
            var material = db.materiales.FirstOrDefault(x => x.idMaterial == id);
            ViewData["codigo"] = material.codigo;
            ViewData["nombre"] = material.nombre;
            return View("Historial", ordenesTrabajo);
        }

        private void cargarTipoMaterial(object selectedTipoMaterial = null)
        {
            ViewBag.idTipoMaterial = new SelectList(db.tipoMaterial.ToList(), "idTipoMaterial", "nombre", selectedTipoMaterial);
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            ViewBag.idProveedor = new SelectList(db.proveedores.Where(x => x.hab).ToList(), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            ViewBag.idUnidad = new SelectList(db.unidades.ToList(), "idUnidad", "nombre", selectedUnidad);
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Material/GetMaterial/{id}")]
        [HttpGet]
        public JsonResult GetMaterial(string codigo)
        {
            var material = from mat in db.materiales
                           where mat.codigo.ToUpper().Equals(codigo.ToUpper())
                           select new { mat.codigo, mat.nombre };

            return Json(new { Name = "/GetMaterial", Response = material, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Material/GetMateriales")]
        [HttpGet]
        public JsonResult GetMateriales()
        {
            var materiales = from m in db.materiales
                           where m.hab == true
                           select new { m.idMaterial, m.codigo, m.nombre, m.stockActual, m.stockMinimo, m.estado, m.detalle, m.unidad, m.proveedor, m.tipoMaterial };

            return Json(new { Name = "/GetMateriales", Response = materiales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }
    }
}