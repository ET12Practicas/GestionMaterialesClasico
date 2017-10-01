using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class StockController : Controller
    {
        OtContext db = new OtContext();

        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        //GET: Stock/Sumar
        [Route("/Stock/Sumar")]
        public ActionResult Sumar()
        {
            cargarTipoEntrada();
            return View();
        }
        
        //POST: Stock/Sumar
        [HttpPost]
        public ActionResult Sumar(Material unMaterial, int sumaActual)
        {
            try
            {
                unMaterial.stockActual = unMaterial.stockActual + sumaActual;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Sumar", "Material");
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            ViewBag.TipoEntrada_Id = new SelectList(db.TipoEntrada.ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
        }
    }
}