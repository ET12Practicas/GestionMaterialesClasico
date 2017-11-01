using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class StockController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();

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
            return View("Sumar");
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
            ViewBag.TipoEntrada_Id = new SelectList(db.tipoEntrada.ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
        }
    }
}