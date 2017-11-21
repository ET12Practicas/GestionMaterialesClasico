using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();
        
        // GET: OrdenTrabajo
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/OrdenTrabajo")]
        [HttpGet]
        public ActionResult Index()
        {
            List<OrdenTrabajo> ordenesTrabajo = db.ordenTrabajo.Where(x => x.hab).ToList();
            return View(ordenesTrabajo);
        }
        
        // GET: OrdenTrabajo/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajo/Agregar")]
        [HttpGet]
        public ActionResult Agregar()
        {
            cargarJefeSeccion();
            cargarResponsable();
            cargarTurno();
            return View();
        }

        //POST: OrdenTrabajo/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Agregar(OrdenTrabajo aOT)
        {
            int idOt = -1;

            if (db.ordenTrabajo.Any(y => y.numero == aOT.numero))
            {
                ViewBag.Result = 1;
                cargarJefeSeccion();
                cargarResponsable();
                cargarTurno();
                return View("Agregar", aOT);
            }
            
            try
            {
                Turno t = db.turnos.Find(aOT.idTurno);
                Personal jefe = db.personal.Find(aOT.idJefeSeccion);
                Personal res = db.personal.Find(aOT.idResponsable);
                db.ordenTrabajo.Add(new OrdenTrabajo(aOT.numero, aOT.nombre, t, aOT.fecha, jefe, res));
                db.SaveChanges();
                
                idOt = db.ordenTrabajo.SingleOrDefault(x => x.numero == aOT.numero).idOrdenTrabajo;
            }
            catch
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }
            
            if (idOt < 0)
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }

        //GET: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajo/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id, int nro, string name)
        {
            OrdenTrabajo ordenSelect = db.ordenTrabajo.Find(id);
            cargarJefeSeccion(ordenSelect.idJefeSeccion);
            cargarResponsable(ordenSelect.idResponsable);
            cargarTurno(ordenSelect.idTurno);
            ViewData["numero"] = nro;
            ViewData["nombre"] = name;
            return View(ordenSelect);
        }

        //POST: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajo aOT)
        {
            int idOt = -1;
            OrdenTrabajo otEdit = db.ordenTrabajo.Find(id);
            if (db.ordenTrabajo.Where(x => x.idOrdenTrabajo != id).Any(y => y.numero == aOT.numero))
            {
                ViewBag.Result = 1;
                cargarJefeSeccion(otEdit.idJefeSeccion);
                cargarResponsable(otEdit.idResponsable);
                cargarTurno(otEdit.idTurno);
                return View("Editar", otEdit);
            }
            try
            {
                Turno t = db.turnos.Find(aOT.idTurno);
                Personal jefe = db.personal.Find(aOT.idJefeSeccion);
                Personal res = db.personal.Find(aOT.idResponsable);

                otEdit.numero = aOT.numero;
                otEdit.nombre = aOT.nombre;
                otEdit.idTurno = t.idTurno;
                otEdit.Turno = t;
                otEdit.fecha = aOT.fecha;
                otEdit.responsable = res;
                otEdit.idResponsable = res.idPersonal;
                otEdit.jefeSeccion = jefe;
                otEdit.idJefeSeccion = jefe.idPersonal;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Errpr406", "Error");
            }

            idOt = otEdit.idOrdenTrabajo;

            if(idOt < 0)
            {
                return RedirectToAction("Error406", "Error");
            }
            
            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }

        private void cargarTurno(object selectedTurno = null)
        {
            ViewBag.idTurno = new SelectList(db.turnos.ToList(), "idTurno", "nombre", selectedTurno);
        }

        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            ViewBag.idJefeSeccion = new SelectList(db.personal.Where(x => x.hab).ToList(), "idPersonal", "nombre", selectedJefeSeccion);
        }

        private void cargarResponsable(object selectedResponsable = null)
        {
            ViewBag.idResponsable = new SelectList(db.personal.Where(x => x.hab).ToList(), "idPersonal", "nombre", selectedResponsable);
        }
    }
}