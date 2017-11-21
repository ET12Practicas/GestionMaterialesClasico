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
                db.materiales.Add(new Material(aMat.codigo, aMat.nombre, aMat.stockMinimo, aMat.detalle, u, p, tm));
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
        public ActionResult Historial(int id, string cod, string name)
        {
            List<OrdenTrabajo> ordenesTrabajo = db.ordenTrabajo.Where(x => x.itemsOT.Any(y => y.idMaterial == id)).ToList();
            ViewData["codigo"] = cod;
            ViewData["nombre"] = name;
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
    }
}