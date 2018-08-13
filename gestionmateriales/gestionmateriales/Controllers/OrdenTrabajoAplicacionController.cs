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
        // GET: OrdenTrabajo
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/OrdenTrabajoAplicacion")]
        [HttpGet]
        public ActionResult Index()
        {
            //List<OrdenTrabajoAplicacion> ordenesTrabajo = db.ordenTrabajoAplicacion.Where(x => x.hab).ToList();
            return View("Index");
        }

        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/OrdenTrabajoAplicacion/GetOTA")]
        [HttpGet]
        public JsonResult GetOTA()
        {
            var db = new OficinaTecnicaEntities();
            var ota = from o in db.ordenTrabajoAplicacion
                      where o.hab == true
                      select new { id = o.idOrdenTrabajoAplicacion, num = o.numero, fecha = o.fecha, turno = o.turno.nombre, nombre = o.nombre, res = o.responsable.nombre, jds = o.jefeSeccion.nombre, cant = o.itemsOTA.Count };
            return Json(new { Name = "/GetOTA", Response = ota, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
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
            var db = new OficinaTecnicaEntities();

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

            return RedirectToAction("Materiales", new { id = idOt });
        }

        //GET: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var db = new OficinaTecnicaEntities();
            var ordenSelect = db.ordenTrabajoAplicacion
                .Where(x => x.idOrdenTrabajoAplicacion == id)
                .Include(x => x.jefeSeccion)
                .Include(x => x.responsable)
                .FirstOrDefault();

            cargarJefeSeccion(ordenSelect.jefeSeccion.idPersonal);
            cargarResponsable(ordenSelect.responsable.idPersonal);
            cargarTurno(ordenSelect.idTurno);
            ViewData["numero"] = ordenSelect.numero;
            ViewData["nombre"] = ordenSelect.nombre;
            return View(ordenSelect);
        }

        //POST: OrdenTrabajo/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajoAplicacion aOT)
        {
            var db = new OficinaTecnicaEntities();
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

            ViewData["IdOT"] = idOt;

            return RedirectToAction("Materiales", new { id = idOt });
        }

        private void cargarTurno(object selectedTurno = null)
        {
            var db = new OficinaTecnicaEntities();
            ViewBag.idTurno = new SelectList(db.turnos.ToList(), "idTurno", "nombre", selectedTurno);
        }

        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            var db = new OficinaTecnicaEntities();
            ViewBag.idJefeSeccion = new SelectList(db.personal.Where(x => x.hab).ToList(), "idPersonal", "nombre", selectedJefeSeccion);
        }

        private void cargarResponsable(object selectedResponsable = null)
        {
            var db = new OficinaTecnicaEntities();
            ViewBag.idResponsable = new SelectList(db.personal.Where(x => x.hab).ToList(), "idPersonal", "nombre", selectedResponsable);
        }

        // GET: OrdenTrabajo
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/Materiales/{id}")]
        [HttpGet]
        public ActionResult Materiales(int id)
        {
            var db = new OficinaTecnicaEntities();
            var ot = db.ordenTrabajoAplicacion.FirstOrDefault(x => x.idOrdenTrabajoAplicacion == id);
            if (ot == null) throw new Exception("La OTA no existe");
            ViewData["idOt"] = id;
            ViewData["numero"] = ot.numero;
            ViewData["nombre"] = ot.nombre;
            return View("Materiales");
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/GetMateriales/{id}")]
        [HttpGet]
        public JsonResult GetMateriales(int id)
        {
            var db = new OficinaTecnicaEntities();
            int cantMat;
            var itemsMateriales = new List<object>();
            var ot = db.ordenTrabajoAplicacion.Find(id);
            var items = db.ItemOTA.Where(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id).ToList();
            foreach (Material mat in db.materiales.Where(x => x.hab))
            {
                cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                itemsMateriales.Add(new { idOT = ot.idOrdenTrabajoAplicacion, idMat = mat.idMaterial, codMat = mat.codigo, nomMat = mat.nombre, stkMat = mat.stockActual, cant = cantMat });
            }

            return Json(new { Name = "/GetMateriales", Response = itemsMateriales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        private int getCantidadByIdMaterial(List<ItemOrdenTrabajoAplicacion> items, int idMaterial)
        {
            ItemOrdenTrabajoAplicacion item = items.FirstOrDefault(x => x.material.idMaterial == idMaterial);
            if (item != null)
                return item.cantidad;
            return 0;
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenTrabajoAplicacion/AddItemMaterial")]
        [HttpPost]
        public ActionResult AddItemMaterial(int id, int idMaterial, int cant)
        {
            var db = new OficinaTecnicaEntities();
            var ot = db.ordenTrabajoAplicacion.Where(x => x.idOrdenTrabajoAplicacion == id).Include(x => x.itemsOTA).SingleOrDefault();
            if (ot == null) throw new Exception("No existe la orden de trabajo");
            //var ot = db.ordenTrabajoAplicacion.Find(id);
            var mat = db.materiales.Find(idMaterial);
            if (mat == null) throw new Exception("No el material");
            try
            {
                //if (!ot.itemsOTA.Any(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id && x.material.idMaterial == idMaterial))
                //{
                //    ot.itemsOTA.Add(new ItemOrdenTrabajoAplicacion { idOrdenTrabajoAplicacion = ot.idOrdenTrabajoAplicacion, ordenTrabajoAplicacion = ot, idMaterial = idMaterial, material = mat, cantidad = cant });
                //}
                //else
                //{
                //    var item = ot.itemsOTA.FirstOrDefault(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id && x.material.idMaterial == idMaterial);
                //    if (item != null)
                //    {
                //        item.cantidad = cant;
                //    }
                //}

                var itemOTA = ot.itemsOTA.FirstOrDefault(x => x.material.idMaterial == idMaterial);
                if (itemOTA != null)
                {
                    itemOTA.cantidad = cant;
                }
                else
                {
                    ot.itemsOTA.Add(new ItemOrdenTrabajoAplicacion { ordenTrabajoAplicacion = ot, material = mat, cantidad = cant });
                }

                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return Json("das");
        }
    }
}