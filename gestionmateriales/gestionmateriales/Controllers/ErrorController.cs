using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error 406 - Not Acceptable
        public ActionResult Error406()
        {
            return View();
        }

        // GET: Error 404 - Not Found
        public ActionResult Error404()
        {
            return View();
        }

        // GET: Error 500 - Internal Server Error
        public ActionResult Error500()
        {
            return View();
        }
    }
}