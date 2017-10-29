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
        [Route("/Material")]
        public ActionResult Index()
        {
            List<Material> materiales = db.materiales.Where(x => x.hab).ToList();
            return View(materiales);
        }

        //GET: Material/Agregar
        [Route("/Material/Agregar")]
        public ActionResult Agregar()
        {
            cargarProveedor();
            cargarUnidad();
            cargarTipoMaterial();
            return View();
        }
                
        //POST: Material/Agregar
        [HttpPost]
        public ActionResult Agregar(Material aMat)
        {
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
                return RedirectToAction("Index", "Material");
            }
            cargarProveedor();
            cargarUnidad();
            cargarTipoMaterial();
            ViewBag.Result = true;
            return View("Agregar", aMat);
        }

        [Route("/Material/Editar/{id}")]
        public ActionResult Editar(int id)
        {
            Material materialSelect = db.materiales.Find(id);
            cargarProveedor(materialSelect.idProveedor);
            cargarUnidad(materialSelect.idUnidad);
            cargarTipoMaterial(materialSelect.idTipoMaterial);
            return View(materialSelect);
        }
      
        //POST: Material/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            Material materialEdit = db.materiales.Find(id);
            
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
                return RedirectToAction("Index", "Material");
            }
            cargarProveedor(materialEdit.idProveedor);
            cargarUnidad(materialEdit.idUnidad);
            cargarTipoMaterial(materialEdit.idTipoMaterial);
            ViewBag.Result = true;
            return View("Editar", unMaterial);
        }
        
        //POST: Material/Borrar/1
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
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Index", "Material");
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