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

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/Sumar")]
        [HttpGet]
        public ActionResult Sumar()
        {
            cargarTipoEntrada();
            return View("Sumar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/Sumar")]
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

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/Restar")]
        [HttpGet]
        public ActionResult Restar()
        {
            cargarTipoSalida();
            return View("Restar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/Restar")]
        [HttpPost]
        public ActionResult Restar(Salida unaSalida)
        {
            try
            {
                Material unMaterial = db.materiales.Where(x => x.codigo == unaSalida.codigoMaterial).SingleOrDefault();
                TipoSalida unTipoSalida = db.tipoSalida.Find(unaSalida.idTipoSalida);
                Salida nuevaSalida = new Salida();
                nuevaSalida.fecha = DateTime.Now;
                nuevaSalida.Material = unMaterial;
                nuevaSalida.codigoMaterial = unMaterial.codigo;
                nuevaSalida.codigoDocumento = unaSalida.codigoDocumento;
                nuevaSalida.cantidad = unaSalida.cantidad;
                nuevaSalida.tipoSalida = unTipoSalida;
                nuevaSalida.CREATED_BY = User.Identity.Name;
                nuevaSalida.CREATION_DATE = DateTime.Now;
                nuevaSalida.CREATION_IP = Request.UserHostAddress;
                nuevaSalida.LAST_UPDATED_BY = User.Identity.Name;
                nuevaSalida.LAST_UPDATED_DATE = DateTime.Now;
                nuevaSalida.LAST_UPDATED_IP = Request.UserHostAddress;
                if (nuevaSalida.HayStockMaterial())
                {
                    nuevaSalida.RestarStockMaterial();
                    db.salidas.Add(nuevaSalida);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Result = 1;
                    cargarTipoSalida();
                    return View("Restar");
                }
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }
            ViewBag.Result = 0;
            cargarTipoSalida();
            return View("Restar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/HistorialIngresos")]
        [HttpGet]
        public ActionResult HistorialIngresos()
        {
            return View("HistorialIngresos");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/HistorialEgresos")]
        [HttpGet]
        public JsonResult GetHistorialEgresos()
        {
            var historialEgresos = from egr in db.salidas
                                   select new { numero = egr.idSalida, codMaterial = egr.codigoMaterial, material = egr.Material.nombre, cantidad = egr.cantidad, tipoSalida = egr.tipoSalida.nombre, codDocumento = egr.codigoDocumento, usuario = egr.LAST_UPDATED_BY, timestamp = egr.LAST_UPDATED_DATE.ToString() };
            return Json(new { Name = "/GetHistorialEgresos", Response = historialEgresos, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/HistorialEgresos")]
        [HttpGet]
        public ActionResult HistorialEgresos()
        {
            return View("HistorialEgresos");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [Route("/Stock/HistorialIngresos")]
        [HttpGet]
        public JsonResult GetHistorialIngresos()
        {
            var historialIngresos = from ing in db.entradas
                                    select new { numero = ing.idEntrada, codMaterial = ing.codigoMaterial, material = ing.Material.nombre, cantidad = ing.cantidad, tipoEntrada = ing.tipoEntrada.nombre, codDocumento = ing.codigoDocumento, usuario = ing.LAST_UPDATED_BY, timestamp = ing.LAST_UPDATED_DATE.ToString() };
            return Json(new { Name = "/GetHistorialIngresos", Response = historialIngresos, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        private void cargarTipoSalida(object selectedTipoSalida = null)
        {
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoSalida = new SelectList(db.tipoSalida.ToList(), "idTipoSalida", "nombre", selectedTipoSalida);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoSalida = new SelectList(db.tipoSalida.Where(x => x.idSector == 1).ToList(), "idTipoSalida", "nombre", selectedTipoSalida);
            if (User.IsInRole("compras"))
                ViewBag.IdTipoSalida = new SelectList(db.tipoSalida.Where(x => x.idSector == 0).ToList(), "idTipoSalida", "nombre", selectedTipoSalida);
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoEntrada = new SelectList(db.tipoEntrada.ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoEntrada = new SelectList(db.tipoEntrada.Where(x => x.idSector == 1).ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
            if (User.IsInRole("compras"))
                ViewBag.IdTipoEntrada = new SelectList(db.tipoEntrada.Where(x => x.idSector == 0).ToList(), "idTipoEntrada", "nombre", selectedTipoEntrada);
        }
    }
}