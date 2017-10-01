using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class AyudaController : Controller
    {
        // GET: Ayuda
        [Route("/Ayuda")]
        public ActionResult Index()
        {
            return View();
        }
    }
}