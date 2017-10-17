using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;
using System.Collections.Generic;

namespace gestionmateriales.Controllers
{
    public class PersonalController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Personal
        [Route("/Personal")]
        public ActionResult Index()
        {
            List<Personal> personas = db.Personal.Where(x => x.habilitado == true).ToList();

            return View(personas);
        }

        // GET: Personal/Agregar
        [Route("/Personal/Agregar")]
        public ActionResult Agregar()
        {
            return View("Agregar");
        }

        //POST: Personal/Agregar
        [HttpPost]
        public ActionResult Agregar(Personal aPersonal)
        {
            try
            {
                db.Personal.Add(aPersonal);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Personal");
            }
            ViewBag.Result = true;
            return View("Agregar", aPersonal);
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
            
            ViewBag.Result = true;
            
            return View("Editar", nuevoPersonal);
        }

        //POST: Personal/Borrar/1
        public ActionResult Borrar(int id)
        {
            Personal personalSeleccionado = db.Personal.Find(id);
            
            try
            {
                personalSeleccionado.habilitado = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("index", "Personal");
            }
            
            return RedirectToAction("Index", "Personal");
        }
    }
}
