using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class PersonalController : Controller
    {
        pp67_gestionmaterialesEntities db = new pp67_gestionmaterialesEntities();
        //ot_gestionmaterialesEntities db = new ot_gestionmaterialesEntities();

        // GET: Personal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Personal/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_asc" : "";
            ViewBag.ApellidoSortParm = String.IsNullOrEmpty(sortOrder) ? "apellido_asc" : "";
            
            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<personal> staff = db.personal.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.personal.Where(s => s.apellido.ToUpper().Contains(searchString.ToUpper()) || s.nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nombre_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
                case "apellido_asc":
                    staff = staff.OrderBy(s => s.apellido).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        // GET: Personal/Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: Personal/1/Agregar
        [HttpPost]
        public ActionResult Agregar(personal unPersonal)
        {
            try
            {
                db.personal.Add(new personal {nombre = unPersonal.nombre, apellido = unPersonal.apellido, fichaCensal = unPersonal.fichaCensal, dni = unPersonal.dni});
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Personal");
            }

            return RedirectToAction("Agregar", "Personal");
        }

        //GET: Personal/Editar/1
        public ActionResult Editar(int id)
        {
            personal personalSeleccionado;

            try
            {
                personalSeleccionado = db.personal.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Personal");
            }

            return View(personalSeleccionado);
        }
      
        //POST: Personal/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, personal unPersonal)
        {
            personal nuevoPersonal = db.personal.Find(id);
            try
            {
                nuevoPersonal.nombre = unPersonal.nombre;
                nuevoPersonal.apellido = unPersonal.apellido;
                nuevoPersonal.dni = unPersonal.dni;
                nuevoPersonal.fichaCensal = unPersonal.fichaCensal;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Personal");
            }

            return RedirectToAction("Buscar", "Personal");
        }

        //POST: Personal/Borrar/1
        public ActionResult Borrar(int id)
        {
            personal nuevoPersonal = db.personal.Find(id);
            try
            {
                db.personal.Remove(nuevoPersonal);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Personal");
            }

            return RedirectToAction("Buscar", "Personal");
        }
    }
}
