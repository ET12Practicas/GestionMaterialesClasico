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
        [Route("/OrdenTrabajo")]
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: OrdenTrabajo/Alta
        [Route("/OrdenTrabajo/Alta")]
        public ActionResult Alta()
        {
            cargarJefeSeccion();
            cargarResponsable();
            cargarTurno();

            return View();
        }

        //POST: OrdenTrabajo/Alta
        [HttpPost]
        public ActionResult Alta(OrdenTrabajo aOT)
        {
            try
            {
                Turno t = db.Turno.Find(aOT.Turno_Id);
                Personal jefe = db.Personal.Find(aOT.JefeSeccion_Id);
                Personal res = db.Personal.Find(aOT.Responsable_Id);

                db.OrdenTrabajo.Add(new OrdenTrabajo(aOT.nroOrdenTrabajo, aOT.nombreTrabajo, t, aOT.fecha, jefe, res));
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            return RedirectToAction("Alta", "OrdenTrabajo");
        }

        //GET: OrdenTrabajo/Editar/1
        [Route("/OrdenTrabajo/Editar/{id}")]
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
        public ActionResult Editar(int id, OrdenTrabajo aOT)
        {
            OrdenTrabajo nuevaOT = db.OrdenTrabajo.Find(id);

            try
            {
                Turno t = db.Turno.Find(aOT.Turno_Id);
                Personal jefe = db.Personal.Find(aOT.JefeSeccion_Id);
                Personal res = db.Personal.Find(aOT.Responsable_Id);

                nuevaOT.nroOrdenTrabajo = aOT.nroOrdenTrabajo;
                nuevaOT.nombreTrabajo = aOT.nombreTrabajo;
                nuevaOT.Turno_Id = t.idTurno;
                nuevaOT.Turno = t;
                nuevaOT.fecha = aOT.fecha;
                nuevaOT.Responsable = res;
                nuevaOT.Responsable_Id = res.idPersonal;
                nuevaOT.JefeSeccion = jefe;
                nuevaOT.JefeSeccion_Id = jefe.idPersonal;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "OrdenTrabajo");
            }

            return RedirectToAction("Buscar", "OrdenTrabajo");
        }

        // GET: OrdenTrabajo/Buscar
        [Route("/OrdenTrabajo/Buscar")]
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombreTrabajo_asc" : "";

            ViewBag.CurrentFilter = searchString;

            List<OrdenTrabajo> staff = db.OrdenTrabajo.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //staff = db.OrdenTrabajo.Where(s => s.nombreTrabajo.ToUpper().Contains(searchString.ToUpper())).ToList();
                staff = (from ot in db.OrdenTrabajo
                        where ot.nombreTrabajo.ToUpper().Contains(searchString.ToUpper()) 
                            || ot.nroOrdenTrabajo.ToString().Equals(searchString) || ot.Responsable.nombre.ToUpper().Contains(searchString.ToUpper())
                        select ot).ToList();
            }

            switch (sortOrder)
            {
                case "nombreTrabajo_asc":
                    staff = staff.OrderBy(s => s.nombreTrabajo).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        private void cargarTurno(object selectedTurno = null)
        {
            ViewBag.Turno_Id = new SelectList(db.Turno.ToList(), "idTurno", "nombreTurno", selectedTurno);
        }

        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            ViewBag.JefeSeccion_Id = new SelectList(db.Personal.ToList(), "idPersonal", "nombre", selectedJefeSeccion);
        }

        private void cargarResponsable(object selectedResponsable = null)
        {
            ViewBag.Responsable_Id = new SelectList(db.Personal.ToList(), "idPersonal", "nombre", selectedResponsable);
        }
    }
}