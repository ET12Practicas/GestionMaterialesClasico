using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class ClaseMaterialController : Controller
    {

        pp67_gestionmaterialesEntities db = new pp67_gestionmaterialesEntities();
        //ot_gestionmaterialesEntities db = new ot_gestionmaterialesEntities();


        // GET: ClaseMaterial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alta()
        {
            return View();
        }


        // GET: Material/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_asc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<clasematerial> staff = db.clasematerial.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.clasematerial.Where(s => s.nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nombre_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        //POST: Material/1/Agregar
        [HttpPost]
        public ActionResult Agregar(clasematerial unMaterial)
        {
            try
            {
                db.clasematerial.Add(new clasematerial { nombre = unMaterial.nombre});
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Agregar", "Material");
        }

        //GET: Material/Editar/1
        public ActionResult Editar(int id)
        {
            clasematerial MaterialSeleccionado;

            try
            {
                MaterialSeleccionado = db.clasematerial.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return View(MaterialSeleccionado);
        }

        //POST: Material/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, clasematerial unMaterial)
        {
            clasematerial nuevoClaseMaterial = db.clasematerial.Find(id);
            try
            {
                nuevoClaseMaterial.nombre = unMaterial.nombre;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return RedirectToAction("Buscar", "Material");
        }

        //POST: Material/Borrar/1
        public ActionResult Borrar(int id)
        {
            clasematerial nuevoClaseMaterial = db.clasematerial.Find(id);
            try
            {
                db.clasematerial.Remove(nuevoClaseMaterial);
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