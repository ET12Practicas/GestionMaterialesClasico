﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar()
        {
            return View();

        }
    }

}