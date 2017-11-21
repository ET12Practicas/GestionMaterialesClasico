using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class ContruccionController : Controller
    {
        // GET: Contruccion
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/Contruccion")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}