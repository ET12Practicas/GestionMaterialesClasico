using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class AyudaController : Controller
    {
        // GET: Ayuda
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/Ayuda")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}