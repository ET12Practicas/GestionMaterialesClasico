using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;
using System.Collections.Generic;

namespace gestionmateriales.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        [Route("/Personal")]
        [HttpGet]
        public ActionResult Index()
        {
            List<Personal> personas;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                personas = db.personal.Where(x => x.hab == true).ToList();
            }
            return View("Index", personas);
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
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                if (db.personal.Any(y => y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni))
                {
                    ViewBag.Result = 1;
                    return View("Agregar", aPersonal);
                }
                try
                {
                    db.personal.Add(new Personal(aPersonal.nombre, aPersonal.fichaCensal, aPersonal.dni));
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            ViewBag.Result = 0;
            //TODO Fix: Se ve la animacion y desencadena en error de duplicados, es mejor que se limpie en form
            //return View("Agregar", new Personal()); 
            return RedirectToAction("Agregar","Personal");
        }

        //GET: Personal/Editar/1
        [Route("/Personal/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            Personal personalSeleccionado;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {               
                try
                {
                    personalSeleccionado = db.personal.Find(id);
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            return View("Editar", personalSeleccionado);
        }
      
        //POST: Personal/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Personal aPersonal)
        {
            Personal nuevoPersonal;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                nuevoPersonal = db.personal.Find(id);
                if (db.personal.Where(x => x.idPersonal != id).Any(y => y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni))
                {
                    ViewBag.Result = 1;
                    return View("Editar", nuevoPersonal);
                }
                try
                {
                    nuevoPersonal.nombre = aPersonal.nombre;
                    nuevoPersonal.dni = aPersonal.dni;
                    nuevoPersonal.fichaCensal = aPersonal.fichaCensal;
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            ViewBag.Result = 0;
            //TODO Fix: Se ve la animacion y desencadena en error de duplicados, es mejor que se limpie en form
            //return View("Agregar", new Personal()); 
            return RedirectToAction("Agregar", "Personal");
        }

        //POST: Personal/Borrar/1
        public ActionResult Borrar(int id)
        {
            Personal personalSeleccionado;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                personalSeleccionado = db.personal.Find(id);
                try
                {
                    personalSeleccionado.hab = false;
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            return RedirectToAction("Index", "Personal");
        }
    }
}
