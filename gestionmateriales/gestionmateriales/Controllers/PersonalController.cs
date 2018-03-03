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
            var db = new OficinaTecnicaEntities();
            if (db.personal.Any(y => (y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni) && y.hab))
            {
                ViewBag.Result = 1;
                return View("Agregar", aPersonal);
            }
            try
            {
                //db.personal.Add(new Personal(aPersonal.nombre, aPersonal.dni, aPersonal.fichaCensal));
                var p = new Personal();
                p.nombre = aPersonal.nombre;
                p.dni = aPersonal.dni;
                p.fichaCensal = aPersonal.fichaCensal;
                p.CREATED_BY = User.Identity.Name;
                p.CREATION_DATE = DateTime.Now;
                p.CREATION_IP = Request.UserHostAddress;
                p.LAST_UPDATED_BY = User.Identity.Name;
                p.LAST_UPDATED_DATE = DateTime.Now;
                p.LAST_UPDATED_IP = Request.UserHostAddress;
                db.personal.Add(p);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
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
            var db = new OficinaTecnicaEntities();
            Personal p = db.personal.Find(id);
            if (db.personal.Where(x => x.idPersonal != id && x.hab).Any(y => y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni))
            {
                ViewBag.Result = 1;
                return View("Editar", p);
            }
            try
            {
                p.nombre = aPersonal.nombre;
                p.dni = aPersonal.dni;
                p.fichaCensal = aPersonal.fichaCensal;
                p.LAST_UPDATED_BY = User.Identity.Name;
                p.LAST_UPDATED_DATE = DateTime.Now;
                p.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            ViewBag.Result = 0;
            return View("Editar", p);
        }
        //POST: Personal/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult Borrar(int id)
        {
            var db = new OficinaTecnicaEntities();
            Personal p = db.personal.Find(id);
            try
            {
                p.hab = false;
                p.LAST_UPDATED_BY = User.Identity.Name;
                p.LAST_UPDATED_DATE = DateTime.Now;
                p.LAST_UPDATED_IP = Request.UserHostAddress;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            return RedirectToAction("Index", "Personal");
        }

        [HttpGet]
        [Route("/Personal/GetPersonal")]
        public JsonResult GetPersonal()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            var personas = from per in db.personal
                           where per.hab == true
                           select new { per.idPersonal, per.nombre, per.dni, per.fichaCensal };

            return Json(new { Name = "/GetPersonal", Response = personas, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }
    }
}
