using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using gestionmateriales.Models.GestionMateriales;
using System;

namespace gestionmateriales.Controllers
{
    public class StockController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();

        // GET: Stock
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/Stock")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //GET: Stock/Sumar
        [Authorize(Roles = "administrador, oficinatecnica, deposito")]
        [Route("/Stock/Sumar")]
        [HttpGet]
        public ActionResult Sumar()
        {
            cargarTipoEntrada();
            return View("Sumar");
        }

        //POST: Stock/Sumar
        [Authorize(Roles = "administrador, oficinatecnica, deposito")]
        [HttpPost]
        public ActionResult Sumar(Entrada unaEntrada)
        {
            try
            {
                Material unMaterial = db.materiales.Where(x => x.codigo == unaEntrada.codigoMaterial).SingleOrDefault();
                TipoEntrada unTipoEntrada = db.tipoEntrada.Find(unaEntrada.idTipoEntrada);
                Entrada nuevaEntrada = new Entrada(DateTime.Now, unMaterial, unMaterial.codigo, unaEntrada.codigoDocumento, unaEntrada.cantidad, unTipoEntrada);
                nuevaEntrada.CREATED_BY = User.Identity.Name;
                nuevaEntrada.CREATION_DATE = DateTime.Now;
                nuevaEntrada.CREATION_IP = Request.UserHostAddress;
                nuevaEntrada.LAST_UPDATED_BY = User.Identity.Name;
                nuevaEntrada.LAST_UPDATED_DATE = DateTime.Now;
                nuevaEntrada.LAST_UPDATED_IP = Request.UserHostAddress;
                nuevaEntrada.SumarStockMaterial();
                db.entradas.Add(nuevaEntrada);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            ViewBag.Result = 0;
            cargarTipoEntrada();
            return View("Sumar");
        }
    
        //GET: Stock/Restar
        [Route("/Stock/Restar")]
        public ActionResult Restar()
        {
            //cargarTipoEntrada();
            return View("Restar");
            //return RedirectToAction("Index", "Construccion");
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            ViewBag.IdTipoEntrada = new SelectList(db.tipoEntrada.Where(x => x.idSector == 0).ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
        }
    }
}