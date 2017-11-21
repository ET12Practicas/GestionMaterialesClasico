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
        [Route("/Stock/Sumar")]
        [HttpPost]
        public ActionResult Sumar(Entrada unaEntrada)
        {
            try
            {
                Material unMaterial = db.materiales.Where(x => x.codigo == unaEntrada.codigo).SingleOrDefault();
                TipoEntrada unTipoEntrada = db.tipoEntrada.Find(unaEntrada.idTipoEntrada);
                Entrada nuevaEntrada = new Entrada(DateTime.Now, unMaterial, unMaterial.codigo, unaEntrada.cantidad, unTipoEntrada);
                nuevaEntrada.SumarStockMaterial();
                db.entradas.Add(nuevaEntrada);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            cargarTipoEntrada();
            return RedirectToAction("Sumar", "Stock");
        }
    
        //GET: Stock/Restar
        [Route("/Stock/Restar")]
        public ActionResult Restar()
        {
            cargarTipoEntrada();
            return View("Restar");
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            ViewBag.IdTipoEntrada = new SelectList(db.tipoEntrada.ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
        }
    }
}