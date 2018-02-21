using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;
using System.Collections.Generic;
using System;

namespace gestionmateriales.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [HttpGet]
        [Route("/Personal")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("/Personal/GetPersonal")]
        public JsonResult GetPersonal()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            //personas = db.personal.Where(x => x.hab == true).ToList();
            var personas = from per in db.personal
                           where per.hab == true
                           select new { per.idPersonal, per.nombre, per.dni, per.fichaCensal };

            return Json(new { Name = "/GetPersonal", Response = personas, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")}, JsonRequestBehavior.AllowGet);
        }

        // GET: Personal/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/Personal/Agregar")]
        [HttpGet]
        public ActionResult Agregar()
        {
            return View("Agregar");
        }

        //POST: Personal/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Agregar(Personal aPersonal)
        {
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                if (db.personal.Any(y => (y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni) && y.hab))
                {
                    ViewBag.Result = 1;
                    return View("Agregar", aPersonal);
                }
                try
                {
                    db.personal.Add(new Personal(aPersonal.nombre, aPersonal.dni, aPersonal.fichaCensal));
                    db.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Error406", "Error");
                }
            }
            ViewBag.Result = 0;
            return View("Agregar"); 
        }

        //GET: Personal/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
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
        [Authorize(Roles = "administrador, oficinatecnica")]
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
            return View("Editar", nuevoPersonal); 
        }

        //POST: Personal/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
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
