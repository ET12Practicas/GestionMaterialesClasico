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
            return View();
        }

        //POST: Material/Agregar
        [HttpPost]
        public ActionResult Alta(Material unMaterial)
        {
            try
            {
                db.Material.Add(new Material { codigo = unMaterial.codigo, nombre = unMaterial.nombre, stockMinimo = unMaterial.stockMinimo });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Materiales");
            }

            return RedirectToAction("Agregar", "Materiales");
        }

        //GET: Materiales/Editar/1
        public ActionResult Editar(int id)
        {
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
    }

}