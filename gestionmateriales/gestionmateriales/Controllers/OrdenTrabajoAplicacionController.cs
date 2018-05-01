using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;

namespace gestionmateriales.Controllers
{
    public class OrdenTrabajoAplicacionController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();
        
        // GET: OrdenTrabajo
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/OrdenTrabajoAplicacion")]
        [HttpGet]
        public ActionResult Index()
        {
            List<OrdenTrabajoAplicacion> ordenesTrabajo = db.ordenTrabajoAplicacion.Where(x => x.hab).ToList();
            return View(ordenesTrabajo);
        }
        
        // GET: OrdenTrabajo/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/Agregar")]
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
        public ActionResult Agregar(OrdenTrabajoAplicacion aOT)
        {
            int idOt = -1;

            if (db.ordenTrabajoAplicacion.Any(y => y.numero == aOT.numero))
            {
                ViewBag.Result = 1;
                cargarJefeSeccion();
                cargarResponsable();
                cargarTurno();
                return View("Agregar", aOT);
            }

            try
            {
                OrdenTrabajoAplicacion unaOTA = new OrdenTrabajoAplicacion();
                unaOTA.turno = db.turnos.Find(aOT.idTurno);
                unaOTA.jefeSeccion = db.personal.Find(aOT.idJefeSeccion);
                unaOTA.responsable = db.personal.Find(aOT.idResponsable);
                unaOTA.numero = aOT.numero;
                unaOTA.nombre = aOT.nombre;
                unaOTA.fecha = aOT.fecha;
                unaOTA.CREATED_BY = User.Identity.Name;
                unaOTA.CREATION_DATE = DateTime.Now;
                unaOTA.CREATION_IP = Request.UserHostAddress;
                unaOTA.LAST_UPDATED_BY = User.Identity.Name;
                unaOTA.LAST_UPDATED_DATE = DateTime.Now;
                unaOTA.LAST_UPDATED_IP = Request.UserHostAddress;
                db.ordenTrabajoAplicacion.Add(unaOTA);

                db.SaveChanges();
                
                idOt = db.ordenTrabajoAplicacion.SingleOrDefault(x => x.numero == aOT.numero).idOrdenTrabajoAplicacion;
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            
            if (idOt < 0)
            {
                return RedirectToAction("Error406", "Error");
            }

            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }

        //GET: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id, int nro, string name)
        {
            //OrdenTrabajoAplicacion ordenSelect = db.ordenTrabajoAplicacion.Find(id);
            var ordenSelect = db.ordenTrabajoAplicacion
                .Where(x => x.idOrdenTrabajoAplicacion == id)
                .Include(x => x.jefeSeccion)
                .Include(x => x.responsable)
                .FirstOrDefault();

            cargarJefeSeccion(ordenSelect.jefeSeccion.idPersonal);
            cargarResponsable(ordenSelect.responsable.idPersonal);
            cargarTurno(ordenSelect.idTurno);
            ViewData["numero"] = nro;
            ViewData["nombre"] = name;
            return View(ordenSelect);
        }

        //POST: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajoAplicacion aOT)
        {
            int idOt = -1;
            OrdenTrabajoAplicacion otEdit = db.ordenTrabajoAplicacion.Find(id);
            if (db.ordenTrabajoAplicacion.Where(x => x.idOrdenTrabajoAplicacion != id).Any(y => y.numero == aOT.numero))
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
                otEdit.turno = t;
                otEdit.fecha = aOT.fecha;
                otEdit.responsable = res;
                otEdit.idResponsable = res.idPersonal;
                otEdit.jefeSeccion = jefe;
                otEdit.idJefeSeccion = jefe.idPersonal;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }

            idOt = otEdit.idOrdenTrabajoAplicacion;

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