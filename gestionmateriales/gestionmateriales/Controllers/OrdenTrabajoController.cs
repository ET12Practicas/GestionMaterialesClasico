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
        [Route("/OrdenTrabajo")]
        public ActionResult Index()
        {
            List<OrdenTrabajo> ordenesTrabajo = db.ordenTrabajo.Where(x => x.hab).ToList();
            return View(ordenesTrabajo);
        }
        
        // GET: OrdenTrabajo/Agregar
        [Route("/OrdenTrabajo/Agregar")]
        public ActionResult Agregar()
        {
            cargarJefeSeccion();
            cargarResponsable();
            cargarTurno();
            return View();
        }

        //POST: OrdenTrabajo/Agregar
        [HttpPost]
        public ActionResult Agregar(OrdenTrabajo aOT)
        {
            int idOt = -1;
            
            if(db.ordenTrabajo.Any(x => x.numero == aOT.numero))
            {
                return RedirectToAction("Index", "OrdenTrabajo");
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
        [Route("/OrdenTrabajo/Editar/{id}")]
        public ActionResult Editar(int id)
        {
            OrdenTrabajo ordenSelect = db.ordenTrabajo.Find(id);
            cargarJefeSeccion(ordenSelect.idJefeSeccion);
            cargarResponsable(ordenSelect.idResponsable);
            cargarTurno(ordenSelect.idTurno);
            return View(ordenSelect);
        }

        //POST: OrdenTrabajo/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajo aOT)
        {
            int idOt = -1;
            OrdenTrabajo otEdit = db.ordenTrabajo.Find(id);

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
                otEdit.jefeSeccion = jefe;
                db.SaveChanges();
            }
            catch
            {
                //TODO redirect error correspondiente
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            idOt = otEdit.idOrdenTrabajo;

            if(idOt < 0)
            {
                return RedirectToAction("Index", "OrdenTrabajo");
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