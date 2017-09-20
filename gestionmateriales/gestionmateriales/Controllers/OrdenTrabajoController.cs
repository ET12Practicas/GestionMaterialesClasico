using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: OrdenTrabajo
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: OrdenTrabajo/Alta
        public ActionResult Alta()
        {
            return View();
        }

        // GET: OrdenTrabajo/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombreTrabajo_asc" : "";

            ViewBag.CurrentFilter = searchString;

            List<OrdenTrabajo> staff = db.OrdenTrabajo.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.OrdenTrabajo.Where(s => s.nombreTrabajo.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nombreTrabajo_asc":
                    staff = staff.OrderBy(s => s.nombreTrabajo).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        //POST: OrdenTrabajo/1/Alta
        [HttpPost]
        public ActionResult Alta(OrdenTrabajo unaOrdenDeTrabajo)
        {
            try
            {
                db.OrdenTrabajo.Add(new OrdenTrabajo { nombreTrabajo = unaOrdenDeTrabajo.nombreTrabajo, responsable = unaOrdenDeTrabajo.responsable, turno = unaOrdenDeTrabajo.turno, jefeSeccion = unaOrdenDeTrabajo.jefeSeccion});
                db.SaveChanges();
            }
            catch 
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            return RedirectToAction("Agregar", "OrdenTrabajo");
        }
    }
}