using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Material
        [Route("/Material")]
        public ActionResult Index()
        {
            List<Material> materiales = db.Material.Where(x => x.habilitado).ToList();

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
                Unidad u = db.Unidad.Find(aMat.Unidad_Id);
                Proveedor p = db.Proveedor.Find(aMat.Proveedor_Id);
                TipoMaterial tm = db.TipoMaterial.Find(aMat.TipoMaterial_Id);
                db.Material.Add(new Material(aMat.codigo, aMat.nombre, aMat.stockMinimo, aMat.detalle, u, p, tm));
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

            cargarProveedor();

            cargarUnidad();

            cargarTipoMaterial();


            Material materialSeleccionado;

            try
            {
                materialSeleccionado = db.Material.Find(id);
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return View(materialSeleccionado);
        }
      
        //POST: Material/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            Material nuevoMaterial = db.Material.Find(id);
            
            try
            {
                nuevoMaterial.nombre = unMaterial.nombre;
                nuevoMaterial.codigo = unMaterial.codigo;
                nuevoMaterial.Unidad = db.Unidad.Find(unMaterial.Unidad_Id);
                nuevoMaterial.stockMinimo = unMaterial.stockMinimo;
                nuevoMaterial.Proveedor = db.Proveedor.Find(unMaterial.Proveedor_Id);
                nuevoMaterial.TipoMaterial = db.TipoMaterial.Find(unMaterial.TipoMaterial_Id);
                nuevoMaterial.detalle = unMaterial.detalle;
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
            return View("Editar", unMaterial);
        }
        
        //POST: Material/Borrar/1
        public ActionResult Borrar(int id)
        {
            Material nuevoMaterial = db.Material.Find(id);

            try
            {
                //db.Material.Remove(nuevoMaterial);
                nuevoMaterial.habilitado = false;
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
            ViewBag.TipoMaterial_Id = new SelectList(db.TipoMaterial.ToList(), "idTipoMaterial", "nombre", selectedTipoMaterial);
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            ViewBag.Proveedor_Id = new SelectList(db.Proveedor.ToList(), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            ViewBag.Unidad_Id = new SelectList(db.Unidad.ToList(), "idUnidad", "nombre", selectedUnidad);
        }
        
    }
}