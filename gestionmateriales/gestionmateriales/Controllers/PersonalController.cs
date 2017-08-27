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
        OtContext db = new OtContext();
        
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

            List<Personal> staff = db.Personal.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.Personal.Where(s => s.apellido.ToUpper().Contains(searchString.ToUpper()) || s.nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
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
        public ActionResult Agregar(Personal unPersonal)
        {
            try
            {
                db.Personal.Add(new Personal { nombre = unPersonal.nombre, apellido = unPersonal.apellido, fichaCensal = unPersonal.fichaCensal, dni = unPersonal.dni });
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
            Personal personalSeleccionado;

            try
            {
                personalSeleccionado = db.Personal.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Personal");
            }

            return View(personalSeleccionado);
        }
      
        //POST: Personal/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Personal unPersonal)
        {
            Personal nuevoPersonal = db.Personal.Find(id);
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
            Personal nuevoPersonal = db.Personal.Find(id);
            
            try
            {
                db.Personal.Remove(nuevoPersonal);
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
