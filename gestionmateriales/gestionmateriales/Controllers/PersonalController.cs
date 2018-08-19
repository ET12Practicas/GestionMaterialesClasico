using System;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    [Authorize(Roles = "administrador, oficinatecnica")]
    [Route("/Personal")]
    public class PersonalController : Controller
    {
        private IPersonalRepository personalRepository;

        public PersonalController()
        {
            this.personalRepository = new PersonalRepository(new OficinaTecnicaEntities());
        }

        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View("Agregar");
        }

        [HttpPost]
        public ActionResult Agregar(Personal aPersonal)
        {
            if (personalRepository.GetAll().Any(x => (x.fichaCensal == aPersonal.fichaCensal || x.dni == aPersonal.dni) && x.hab))
            {
                ViewBag.Result = 1;

                return View("Agregar", aPersonal);
            }

            try
            {
                personalRepository.Add(new Personal
                {
                    nombre = aPersonal.nombre,
                    dni = aPersonal.dni,
                    fichaCensal = aPersonal.fichaCensal,
                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress
                });
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }

            ViewBag.Result = 0;

            return View("Agregar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var unPersonal = personalRepository.GetById(id);

            if (unPersonal == null) throw new Exception("No existe el personal");

            return View("Editar", unPersonal);
        }

        [HttpPost]
        public ActionResult Editar(int id, Personal aPersonal)
        {
            Personal personal = personalRepository.GetById(id);

            if (personal == null) throw new Exception("No existe el personal");

            if (personalRepository.Find(x => x.idPersonal != id && x.hab).Any(y => y.fichaCensal == aPersonal.fichaCensal || y.dni == aPersonal.dni))
            {
                ViewBag.Result = 1;

                return View("Editar", personal);
            }

            try
            {
                personal.nombre = aPersonal.nombre;

                personal.dni = aPersonal.dni;

                personal.fichaCensal = aPersonal.fichaCensal;

                personal.LAST_UPDATED_BY = User.Identity.Name;

                personal.LAST_UPDATED_DATE = DateTime.Now;

                personal.LAST_UPDATED_IP = Request.UserHostAddress;

                personalRepository.Edit(personal);
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            
            ViewBag.Result = 0;

            return View("Editar", personal);
        }
        
        public ActionResult Borrar(int id)
        {
            Personal personal = personalRepository.GetById(id);

            try
            {
                personal.hab = false;

                personal.LAST_UPDATED_BY = User.Identity.Name;

                personal.LAST_UPDATED_DATE = DateTime.Now;

                personal.LAST_UPDATED_IP = Request.UserHostAddress;

                personalRepository.Remove(personal);
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }

            return RedirectToAction("Index", "Personal");
        }

        [HttpGet]        
        public JsonResult GetAll()
        {
            var personas = personalRepository.Find(x => x.hab).Select(x => new { x.idPersonal, x.nombre, x.dni, x.fichaCensal });

            return Json(new { Response = personas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLastUpdated()
        {
            var fecha = personalRepository.Find(x => x.hab).OrderBy(x => x.LAST_UPDATED_DATE).Take(1).Select(x => new { x.LAST_UPDATED_DATE });

            return Json(new { Response = fecha }, JsonRequestBehavior.AllowGet);
        }
    }
}
