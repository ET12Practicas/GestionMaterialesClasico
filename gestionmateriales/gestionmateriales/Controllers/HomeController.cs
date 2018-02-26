using System.Web.Mvc;
using System.Linq;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Notificacion = 0;
            if (hayMaterialParaComprar())
                ViewBag.Notificacion = 1;
            return View("Index");
        }

        [HttpGet]
        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        private dynamic hayMaterialParaComprar()
        {
            bool notif = false;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                notif = db.materiales.Any(y => y.hab && y.stockActual <= y.stockMinimo);
            }
            return notif;
        }
    }
}