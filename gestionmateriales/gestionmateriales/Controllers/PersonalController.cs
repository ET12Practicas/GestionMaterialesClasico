using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class PersonalController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Personal
        [Route("/Personal")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Personal/Buscar
        [Route("/Personal/Buscar")]
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_asc" : "";
            
            ViewBag.CurrentFilter = searchString;

            List<Personal> staff = db.Personal.Where(x => x.habilitado == true).Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.Personal.Where(s => (s.nombre.ToUpper().Contains(searchString.ToUpper()) || s.nombre.ToUpper().Contains(searchString.ToUpper())) && s.habilitado == true).ToList();
            }

            switch (sortOrder)
            {
                case "nombre_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        // GET: Personal/Agregar
        [Route("/Personal/Agregar")]
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: Personal/Agregar
        [HttpPost]
        public ActionResult Agregar(Personal unPersonal)
        {
            try
            {
                db.Personal.Add(new Personal { nombre = unPersonal.nombre, fichaCensal = unPersonal.fichaCensal, dni = unPersonal.dni, habilitado = true });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Personal");
            }

            return RedirectToAction("Agregar", "Personal");
        }

        //GET: Personal/Editar/1
        [Route("/Personal/Editar/{id}")]
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
            Personal personalSeleccionado = db.Personal.Find(id);
            
            try
            {
               // db.Personal.Remove(personalSeleccionado);
                personalSeleccionado.habilitado = false;
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
