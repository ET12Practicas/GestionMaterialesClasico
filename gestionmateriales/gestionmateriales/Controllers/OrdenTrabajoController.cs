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
            cargarJefeSeccion();

            cargarResponsable();

            cargarTurno();

            return View();
        }

        //GET: OrdenTrabajo/Editar/1
        public ActionResult Editar(int id)
        {
            cargarJefeSeccion();

            cargarResponsable();

            cargarTurno();

            OrdenTrabajo ordenSeleccionada;

            try
            {
                ordenSeleccionada = db.OrdenTrabajo.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "OrdenTrabajo");
            }
            
            return View(ordenSeleccionada);
        }

        //POST: OrdenTrabajo/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajo unaOrdenDeTrabajo)
        {
            OrdenTrabajo nuevaOrdenDeTrabajo = db.OrdenTrabajo.Find(id);

            try
            {
                nuevaOrdenDeTrabajo.nombreTrabajo = unaOrdenDeTrabajo.nombreTrabajo;
                nuevaOrdenDeTrabajo.turno = unaOrdenDeTrabajo.turno;
                nuevaOrdenDeTrabajo.responsable = unaOrdenDeTrabajo.responsable;
                nuevaOrdenDeTrabajo.jefeSeccion = unaOrdenDeTrabajo.jefeSeccion;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "OrdenTrabajo");
            }

            return RedirectToAction("Buscar", "OrdenTrabajo");
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

        private void cargarTurno(object selectedTurno = null)
        {
            ViewBag.Turno_Id = new SelectList(db.Turno.ToList(), "idTurno", "nombreTurno", selectedTurno);
        }

        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            ViewBag.JefeSeccion_Id = new SelectList(db.Personal.ToList(), "idPersonal", "apellido", selectedJefeSeccion);
        }

        private void cargarResponsable(object selectedResponsable = null)
        {
            ViewBag.Responsable_Id = new SelectList(db.Personal.ToList(), "idPersonal", "apellido", selectedResponsable);
        }
    }
}