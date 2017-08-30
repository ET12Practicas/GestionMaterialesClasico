using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Material
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Material/Sumar
        [Route("/Material/Sumar")]
        public ActionResult Sumar()
        {
            return View();
        }
        
        // GET: Material/Restar
        public ActionResult Restar()
        {
            return View();
        }
        
        // GET: Material/Agregar
        public ActionResult Alta()
        {
            cargarProveedor();

            cargarUnidad();

            return View();
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            ViewBag.Proveedor_Id = new SelectList(db.Proveedor.ToList(), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            ViewBag.Unidad_Id = new SelectList(db.Unidad.ToList(), "idUnidad", "nombre", selectedUnidad);
        }
        

        //POST: Material/Agregar
        [HttpPost]
        public ActionResult Alta(Material unMaterial)
        {
            try
            {
                Unidad nuevaUnidad = db.Unidad.Find(unMaterial.Unidad_Id);

                db.Material.Add(new Material { codigo = unMaterial.codigo, nombre = unMaterial.nombre, stockMinimo = unMaterial.stockMinimo, 
                    Unidad_Id = unMaterial.Unidad_Id, Proveedor_Id = unMaterial.Proveedor_Id, Unidad = nuevaUnidad });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Alta", "Material");
        }

        //GET: Materiales/Editar/1
        public ActionResult Editar(int id)
        {

            cargarProveedor();

            cargarUnidad();


            Material materialSeleccionado;

            try
            {
                materialSeleccionado = db.Material.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
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
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Materiales");
            }

            return RedirectToAction("Buscar", "Materiales");
        }
        // GET: Material/Buscar

        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.nombreMaterialSortParm = String.IsNullOrEmpty(sortOrder) ? "nombreMaterial_asc" : "";
            ViewBag.nombreMaterialSortParm = String.IsNullOrEmpty(sortOrder) ? "nombreMaterial_desc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<Material> staff = db.Material.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //TODO: Que ???
                staff = db.Material.Where(s => s.nombre.Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nombreMaterial_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
                case "nombreMaterial_desc":
                    staff = staff.OrderByDescending(s => s.nombre).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        public ActionResult Borrar(int id)
        {
            Material nuevoMaterial = db.Material.Find(id);

            try
            {
                db.Material.Remove(nuevoMaterial);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return RedirectToAction("Buscar", "Material");
        }
    }

}