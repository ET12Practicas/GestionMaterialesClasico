using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    [Authorize(Roles = "administrador, oficinatecnica, deposito")]
    [Route("/OrdenTrabajoAplicacion")]
    public class OrdenTrabajoAplicacionController : Controller
    {
        private readonly IOrdenTrabajoAplicacionRepository ordenTrabajoAplicacionRepository;
        private readonly IPersonalRepository personalRepository;
        private readonly ITurnoRepository turnoRepository;
        private readonly IItemOrdenTrabajoAplicacionRepository itemOrdenTrabajoAplicacionRepository;
        private readonly IMaterialRepository materialRepository;

        public OrdenTrabajoAplicacionController()
        {
            var context = new OficinaTecnicaEntities();
            personalRepository = new PersonalRepository(context);
            turnoRepository = new TurnoRepository(context);
            materialRepository = new MaterialRepository(context);
            ordenTrabajoAplicacionRepository = new OrdenTrabajoAplicacionRepository(context);
            itemOrdenTrabajoAplicacionRepository = new ItemOrdenTrabajoAplicacionRepository(context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            //var db = new OficinaTecnicaEntities();
            //var ota = from o in db.ordenTrabajoAplicacion
            //          where o.hab == true
            //          select new { id = o.idOrdenTrabajoAplicacion, num = o.numero, fecha = o.fecha, turno = o.turno.nombre, nombre = o.nombre, res = o.responsable.nombre, jds = o.jefeSeccion.nombre, cant = o.itemsOTA.Count };
            //return Json(new { Name = "/GetOTA", Response = ota, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);

            var otas = from o in ordenTrabajoAplicacionRepository.FindAll()
                       where o.hab == true
                       select new { id = o.idOrdenTrabajoAplicacion, num = o.numero, o.fecha, turno = o.turno.nombre, o.nombre, res = o.responsable.nombre, jds = o.jefeSeccion.nombre, cant = o.itemsOTA.Count };

            return Json(new { Response = otas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            cargarJefeSeccion();

            cargarResponsable();

            cargarTurno();

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(OrdenTrabajoAplicacion aOT)
        {
            int idOt = -1;
            //var db = new OficinaTecnicaEntities();

            if (ordenTrabajoAplicacionRepository.FindAll().Any(y => y.numero == aOT.numero))
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
                unaOTA.turno = turnoRepository.FindById(aOT.idTurno); //db.turnos.Find(aOT.idTurno);
                unaOTA.jefeSeccion = personalRepository.FindById(aOT.idJefeSeccion); // db.personal.Find(aOT.idJefeSeccion);
                unaOTA.responsable = personalRepository.FindById(aOT.idResponsable); //db.personal.Find(aOT.idResponsable);
                unaOTA.numero = aOT.numero;
                unaOTA.nombre = aOT.nombre;
                unaOTA.fecha = aOT.fecha;
                unaOTA.CREATED_BY = User.Identity.Name;
                unaOTA.CREATION_DATE = DateTime.Now;
                unaOTA.CREATION_IP = Request.UserHostAddress;
                unaOTA.LAST_UPDATED_BY = User.Identity.Name;
                unaOTA.LAST_UPDATED_DATE = DateTime.Now;
                unaOTA.LAST_UPDATED_IP = Request.UserHostAddress;
                //db.ordenTrabajoAplicacion.Add(unaOTA);
                ordenTrabajoAplicacionRepository.Add(unaOTA);

                //db.SaveChanges();

                //idOt = db.ordenTrabajoAplicacion.SingleOrDefault(x => x.numero == aOT.numero).idOrdenTrabajoAplicacion;
                idOt = ordenTrabajoAplicacionRepository.FindOne(x => x.numero == aOT.numero).idOrdenTrabajoAplicacion;
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
            
            if (idOt < 0)
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Materiales", new { id = idOt });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //var db = new OficinaTecnicaEntities();
            //var ordenSelect = db.ordenTrabajoAplicacion
            //    .Where(x => x.idOrdenTrabajoAplicacion == id)
            //    .Include(x => x.jefeSeccion)
            //    .Include(x => x.responsable)
            //    .FirstOrDefault();

            var ordenSelect = ordenTrabajoAplicacionRepository.FindById(id);

            cargarJefeSeccion(ordenSelect.jefeSeccion.idPersonal);

            cargarResponsable(ordenSelect.responsable.idPersonal);

            cargarTurno(ordenSelect.idTurno);

            ViewData["numero"] = ordenSelect.numero;

            ViewData["nombre"] = ordenSelect.nombre;

            return View(ordenSelect);
        }

        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajoAplicacion aOT)
        {
            //var db = new OficinaTecnicaEntities();
            int idOt = -1;
            OrdenTrabajoAplicacion otEdit = ordenTrabajoAplicacionRepository.FindById(id); //db.ordenTrabajoAplicacion.Find(id);
            //if (db.ordenTrabajoAplicacion.Where(x => x.idOrdenTrabajoAplicacion != id).Any(y => y.numero == aOT.numero))
            if (ordenTrabajoAplicacionRepository.Find(x => x.idOrdenTrabajoAplicacion != id).Any(y => y.numero == aOT.numero))
            {
                ViewBag.Result = 1;

                cargarJefeSeccion(otEdit.idJefeSeccion);

                cargarResponsable(otEdit.idResponsable);

                cargarTurno(otEdit.idTurno);

                return View("Editar", otEdit);
            }
            try
            {
                Turno t = turnoRepository.FindById(aOT.idTurno); //db.turnos.Find(aOT.idTurno);

                Personal jefe = personalRepository.FindById(aOT.idJefeSeccion); //db.personal.Find(aOT.idJefeSeccion);

                Personal res = personalRepository.FindById(aOT.idResponsable); //db.personal.Find(aOT.idResponsable);

                otEdit.numero = aOT.numero;

                otEdit.nombre = aOT.nombre;

                otEdit.idTurno = t.idTurno;

                otEdit.turno = t;

                otEdit.fecha = aOT.fecha;

                otEdit.responsable = res;

                otEdit.idResponsable = res.idPersonal;

                otEdit.jefeSeccion = jefe;

                otEdit.idJefeSeccion = jefe.idPersonal;

                ordenTrabajoAplicacionRepository.Edit(otEdit);
                //db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            idOt = otEdit.idOrdenTrabajoAplicacion;

            if(idOt < 0)
            {
                return RedirectToAction("Error500", "Error");
            }

            ViewData["IdOT"] = idOt;

            return RedirectToAction("Materiales", new { id = idOt });
        }

        private void cargarTurno(object selectedTurno = null)
        {
            //var db = new OficinaTecnicaEntities();
            ViewBag.idTurno = new SelectList(turnoRepository.FindAll(), "idTurno", "nombre", selectedTurno);
        }

        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            //var db = new OficinaTecnicaEntities();
            ViewBag.idJefeSeccion = new SelectList(personalRepository.Find(x => x.hab), "idPersonal", "nombre", selectedJefeSeccion);
        }

        private void cargarResponsable(object selectedResponsable = null)
        {
            //var db = new OficinaTecnicaEntities();
            ViewBag.idResponsable = new SelectList(personalRepository.Find(x => x.hab), "idPersonal", "nombre", selectedResponsable);
        }

        [HttpGet]
        public ActionResult Materiales(int id)
        {
            //var db = new OficinaTecnicaEntities();
            //var ot = db.ordenTrabajoAplicacion.FirstOrDefault(x => x.idOrdenTrabajoAplicacion == id);
            var ot = ordenTrabajoAplicacionRepository.FindById(id);

            if (ot == null) throw new Exception("La OTA no existe");

            ViewData["idOt"] = id;

            ViewData["numero"] = ot.numero;

            ViewData["nombre"] = ot.nombre;

            return View("Materiales");
        }

        [HttpGet]
        public JsonResult GetMateriales(int id)
        {
            //var db = new OficinaTecnicaEntities();
            int cantMat;
            var itemsMateriales = new List<object>();
            //var ot = db.ordenTrabajoAplicacion.Find(id);
            var ot = ordenTrabajoAplicacionRepository.FindById(id);

            //var items = db.ItemOTA.Where(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id).ToList();
            var items = itemOrdenTrabajoAplicacionRepository.Find(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id).ToList();

            foreach (Material mat in materialRepository.Find(x => x.hab))
            {
                cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                itemsMateriales.Add(new { idOT = ot.idOrdenTrabajoAplicacion, idMat = mat.idMaterial, codMat = mat.codigo, nomMat = mat.nombre, stkMat = mat.stockActual, cant = cantMat });
            }

            //return Json(new { Name = "/GetMateriales", Response = itemsMateriales, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
            return Json(new { Response = itemsMateriales }, JsonRequestBehavior.AllowGet);
        }

        private int getCantidadByIdMaterial(List<ItemOrdenTrabajoAplicacion> items, int idMaterial)
        {
            ItemOrdenTrabajoAplicacion item = items.FirstOrDefault(x => x.material.idMaterial == idMaterial);
            if (item != null)
                return item.cantidad;
            return 0;
        }

        [HttpPost]
        public ActionResult AddItemMaterial(int id, int idMaterial, int cant)
        {
            //var db = new OficinaTecnicaEntities();
            //var ot = db.ordenTrabajoAplicacion.Where(x => x.idOrdenTrabajoAplicacion == id).Include(x => x.itemsOTA).SingleOrDefault();
            var ot = ordenTrabajoAplicacionRepository.FindOne(x => x.idOrdenTrabajoAplicacion == id);

            if (ot == null) throw new Exception("No existe la orden de trabajo");
            //var ot = db.ordenTrabajoAplicacion.Find(id);
            //var mat = db.materiales.Find(idMaterial);
            var mat = materialRepository.FindById(idMaterial);

            if (mat == null) throw new Exception("No el material");

            try
            {
                var itemOTA = ot.itemsOTA.FirstOrDefault(x => x.material.idMaterial == idMaterial);

                if (itemOTA != null)
                {
                    itemOTA.cantidad = cant;
                }
                else
                {
                    ot.itemsOTA.Add(new ItemOrdenTrabajoAplicacion { ordenTrabajoAplicacion = ot, material = mat, cantidad = cant });
                }

                ordenTrabajoAplicacionRepository.Edit(ot);
                //db.SaveChanges();;                
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return Json("das");
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            //var db = new OficinaTecnicaEntities();
            //var ota = db.ordenTrabajoAplicacion.FirstOrDefault(x => x.idOrdenTrabajoAplicacion == id);
            var ota = ordenTrabajoAplicacionRepository.FindById(id);

            if (ota == null) throw new Exception("No existe orden de trabajo de aplicacion");

            return View("Detalle", ota);
        }

        [HttpGet]
        public JsonResult GetItemsOTA(int id)
        {
            //var db = new OficinaTecnicaEntities();
            //var ota = db.ordenTrabajoAplicacion.Where(x => x.idOrdenTrabajoAplicacion == id).Include(x => x.itemsOTA).SingleOrDefault();
            var ota = ordenTrabajoAplicacionRepository.FindOne(x => x.idOrdenTrabajoAplicacion == id);

            if (ota == null) throw new Exception("No existe orden trabajo aplicacion");

            var itemsOTA = from i in ota.itemsOTA
                           select new { cant = i.cantidad, mat = i.material.nombre, fecha = String.Empty };

            //var res = new { num = ota.numero, nom = ota.nombre, turno = ota.turno.nombre, fecha = ota.fecha,
            //    res = ota.responsable.nombre, jds = ota.jefeSeccion.nombre, items = itemsOTA };

            //return Json(new { Name = "/GetItemsOTA", Response = itemsOTA, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
            return Json(new { Response = itemsOTA }, JsonRequestBehavior.AllowGet);
        }
    }
}