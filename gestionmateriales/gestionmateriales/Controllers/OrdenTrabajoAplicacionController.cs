using System;
using System.Collections.Generic;
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
        //declaracion de todos los repositorios que se utilizaran en la clase (solo definir lo necesario)
        private readonly IOrdenTrabajoAplicacionRepository ordenTrabajoAplicacionRepository;
        private readonly IPersonalRepository personalRepository;
        private readonly ITurnoRepository turnoRepository;
        private readonly IItemOrdenTrabajoAplicacionRepository itemOrdenTrabajoAplicacionRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly ISalidaMaterialRepository salidaMaterialRepository;
        private readonly ITipoSalidaMaterialRepository tipoSalidaMaterialRepository;

        //inicializacion del contexto y repositorios
        public OrdenTrabajoAplicacionController()
        {
            OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            personalRepository = new PersonalRepository(context);
            turnoRepository = new TurnoRepository(context);
            materialRepository = new MaterialRepository(context);
            ordenTrabajoAplicacionRepository = new OrdenTrabajoAplicacionRepository(context);
            itemOrdenTrabajoAplicacionRepository = new ItemOrdenTrabajoAplicacionRepository(context);
            salidaMaterialRepository = new SalidaMaterialRepository(context);
            tipoSalidaMaterialRepository = new TipoSalidaMaterialRepository(context);
        }

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Index retorna la vista Index
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Agregar retorna la vista Agergar
        [HttpGet]
        public ActionResult Agregar()
        {
            cargarJefeSeccion();

            cargarResponsable();

            cargarTurno();

            return View();
        }

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Agregar con datos de la vista, los datos se encapsulan en el objeto OrdenTrabajoAplicacion
        [HttpPost]
        public ActionResult Agregar(OrdenTrabajoAplicacion aOT)
        {
            int idOt = -1;

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

                unaOTA.turno = turnoRepository.FindById(aOT.idTurno);

                unaOTA.jefeSeccion = personalRepository.FindById(aOT.idJefeSeccion);

                unaOTA.responsable = personalRepository.FindById(aOT.idResponsable);

                unaOTA.numero = aOT.numero;

                unaOTA.nombre = aOT.nombre;

                unaOTA.fecha = aOT.fecha;

                unaOTA.CREATED_BY = User.Identity.Name;

                unaOTA.CREATION_DATE = DateTime.Now;

                unaOTA.CREATION_IP = Request.UserHostAddress;

                unaOTA.LAST_UPDATED_BY = User.Identity.Name;

                unaOTA.LAST_UPDATED_DATE = DateTime.Now;

                unaOTA.LAST_UPDATED_IP = Request.UserHostAddress;

                ordenTrabajoAplicacionRepository.Add(unaOTA);

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

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Agregar retorna la vista Editar
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var ordenSelect = ordenTrabajoAplicacionRepository.FindById(id);

            cargarJefeSeccion(ordenSelect.jefeSeccion.idPersonal);

            cargarResponsable(ordenSelect.responsable.idPersonal);

            cargarTurno(ordenSelect.idTurno);

            ViewData["numero"] = ordenSelect.numero;

            ViewData["nombre"] = ordenSelect.nombre;

            return View(ordenSelect);
        }

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Editar con datos de la vista, los datos se encapsulan en el objeto OrdenTrabajoAplicacion
        [HttpPost]
        public ActionResult Editar(int id, OrdenTrabajoAplicacion aOT)
        {
            int idOt = -1;

            OrdenTrabajoAplicacion otEdit = ordenTrabajoAplicacionRepository.FindById(id);

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
                Turno turno = turnoRepository.FindById(aOT.idTurno);

                Personal jefe = personalRepository.FindById(aOT.idJefeSeccion);

                Personal responsable = personalRepository.FindById(aOT.idResponsable);

                otEdit.numero = aOT.numero;

                otEdit.nombre = aOT.nombre;

                otEdit.idTurno = turno.idTurno;

                otEdit.turno = turno;

                otEdit.fecha = aOT.fecha;

                otEdit.responsable = responsable;

                otEdit.idResponsable = responsable.idPersonal;

                otEdit.jefeSeccion = jefe;

                otEdit.idJefeSeccion = jefe.idPersonal;

                ordenTrabajoAplicacionRepository.Edit(otEdit);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            idOt = otEdit.idOrdenTrabajoAplicacion;

            if (idOt < 0)
            {
                return RedirectToAction("Error500", "Error");
            }

            ViewData["IdOT"] = idOt;

            return RedirectToAction("Materiales", new { id = idOt });
        }

        //carga el combobox de turnos
        private void cargarTurno(object selectedTurno = null)
        {
            ViewBag.idTurno = new SelectList(turnoRepository.FindAll(), "idTurno", "nombre", selectedTurno);
        }

        //carga el combobox de jefe de seccion con personal
        private void cargarJefeSeccion(object selectedJefeSeccion = null)
        {
            ViewBag.idJefeSeccion = new SelectList(personalRepository.Find(x => x.hab), "idPersonal", "nombre", selectedJefeSeccion);
        }

        //carga el combobox de responsable con personal
        private void cargarResponsable(object selectedResponsable = null)
        {
            ViewBag.idResponsable = new SelectList(personalRepository.Find(x => x.hab), "idPersonal", "nombre", selectedResponsable);
        }

        //Si se llama /aplicacion/OrdenTrabajoAplicacion/Materiales/1 retorna la vista para agregar/editar los materiales de la OTA
        [HttpGet]
        public ActionResult Materiales(int id)
        {
            var ot = ordenTrabajoAplicacionRepository.FindById(id);

            if (ot == null) throw new Exception("La OTA no existe");

            ViewData["idOt"] = id;

            ViewData["numero"] = ot.numero;

            ViewData["nombre"] = ot.nombre;

            return View("Materiales");
        }

        //Retorna JSON de los todos los materiales disponibles en el sistema
        [HttpGet]
        public JsonResult GetMateriales(int id)
        {
            int cantMat;

            var itemsMateriales = new List<object>();
            
            var ot = ordenTrabajoAplicacionRepository.FindById(id);

            var items = itemOrdenTrabajoAplicacionRepository.Find(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id).ToList();

            foreach (Material mat in materialRepository.Find(x => x.hab))
            {
                cantMat = getCantidadByIdMaterial(items, mat.idMaterial);

                itemsMateriales.Add(new { idOT = ot.idOrdenTrabajoAplicacion, idMat = mat.idMaterial, codMat = mat.codigo, nomMat = mat.nombre, stkMat = mat.stockActual, cant = cantMat });
            }

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
            var ot = ordenTrabajoAplicacionRepository.FindOne(x => x.idOrdenTrabajoAplicacion == id);

            if (ot == null) throw new Exception("No existe la orden de trabajo");

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
            var ota = ordenTrabajoAplicacionRepository.FindById(id);

            if (ota == null) throw new Exception("No existe orden de trabajo de aplicacion");

            return View("Detalle", ota);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var otas = from o in ordenTrabajoAplicacionRepository.FindAll()
                       where o.hab == true
                       select new { id = o.idOrdenTrabajoAplicacion, num = o.numero, o.fecha, turno = o.turno.nombre, o.nombre, res = o.responsable.nombre, jds = o.jefeSeccion.nombre, cant = o.itemsOTA.Count };

            return Json(new { Response = otas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetItemsOTA(int id)
        {
            var ota = ordenTrabajoAplicacionRepository.FindOne(x => x.idOrdenTrabajoAplicacion == id);
            string num = ota.numero.ToString();
            if (ota == null) throw new Exception("No existe orden trabajo aplicacion");

            //var itemsOTA = from i in ota.itemsOTA
            //               select new { cant = i.cantidad, mat = i.material.nombre, fecha = String.Empty, cantRet = GetCantidadRetirada(i.ordenTrabajoAplicacion.numero, i.material.idMaterial ) };
            //var itemsOTA = from i in ota.itemsOTA
            //               join mat in salidaMaterialRepository.Find(x => x.idTipoSalidaMaterial == 2 && x.codigoDocumento == num)
            //               on i.material.idMaterial equals mat.idMaterial
            //               select new { cant = i.cantidad, mat = i.material.nombre, fecha = String.Empty, cantRet = mat.cantidad };

            var itemsOTA = from i in ota.itemsOTA
                           select new { cant = i.cantidad, mat = i.material.nombre, fecha = String.Empty, cantRet = 0};

            return Json(new { Response = itemsOTA }, JsonRequestBehavior.AllowGet);
        }

        //private int GetCantidadRetirada(int numOTA, int idMat)
        //{
        //    string num = numOTA.ToString();

        //    var salidas = salidaMaterialRepository.Find(x => x.idTipoSalidaMaterial == 2 && x.codigoDocumento == num);

        //    return salidas.Where(x => x.idMaterial == idMat).Sum(x => x.cantidad);
        //}

        [HttpGet]
        public JsonResult GetLastUpdated()
        {
            var fecha = ordenTrabajoAplicacionRepository.Find(x => x.hab).OrderBy(x => x.LAST_UPDATED_DATE).Take(1).Select(x => new { x.LAST_UPDATED_DATE });

            return Json(new { Response = fecha }, JsonRequestBehavior.AllowGet);
        }
    }
}