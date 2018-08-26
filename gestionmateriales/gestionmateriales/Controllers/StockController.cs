using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using System.Data.Entity;
using System.Collections.Generic;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    [Route("/Stock")]
    public class StockController : Controller
    {
        //private readonly ISalidaMaterialRepository salidaMaterialRepository;
        //private readonly IEntradaMaterialRepository entradaMaterialRepository;
        //private readonly IMaterialRepository materialRepository;
        //private readonly ITipoEntradaMaterialRepository tipoEntradaMaterialRepository;

        public StockController()
        {
            //OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            //entradaMaterialRepository = new EntradaMaterialRepository(context);
            //salidaMaterialRepository = new SalidaMaterialRepository(context);
            //materialRepository = new MaterialRepository(context);
            //tipoEntradaMaterialRepository = new TipoEntradaMaterialRepository(context);
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public ActionResult Sumar()
        {
            cargarTipoEntrada();

            return View("Sumar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpPost]
        public ActionResult Sumar(EntradaMaterial unaEntrada)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();

            Material unMaterial = db.materiales
                   .Where(x => x.codigo == unaEntrada.codigoMaterial && x.hab)
                   .Include(x => x.proveedor)
                   .Include(x => x.tipoMaterial)
                   .Include(x => x.unidad)
                   .Include(x => x.entradas)
                   .Include(x => x.salidas)
                   .FirstOrDefault();

            if (unMaterial == null) throw new Exception("No existe el material");

            TipoEntradaMaterial unTipoEntrada = db.tipoEntrada.Find(unaEntrada.idTipoEntradaMaterial);

            if (unTipoEntrada == null) throw new Exception("No existe el tipo entrada material");

            try
            {
                //actualizo el stock de la entrada para el material indicado
                unMaterial.stockActual += unaEntrada.cantidad;

                EntradaMaterial nuevaEntrada = new EntradaMaterial()
                {
                    fecha = DateTime.Now,
                    codigoDocumento = unaEntrada.codigoDocumento,
                    codigoMaterial = unMaterial.codigo,
                    cantidad = unaEntrada.cantidad,
                    material = unMaterial,
                    tipoEntradaMaterial = unTipoEntrada,

                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress,
                };

                db.entradas.Add(nuevaEntrada);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
            ViewBag.Result = 0;

            cargarTipoEntrada();

            return View("Sumar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public ActionResult Restar()
        {
            cargarTipoSalida();
            return View("Restar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpPost]
        public ActionResult Restar(SalidaMaterial unaSalida)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();

            Material unMaterial = db.materiales
                   .Where(x => x.codigo == unaSalida.codigoMaterial && x.hab)
                   .Include(x => x.proveedor)
                   .Include(x => x.tipoMaterial)
                   .Include(x => x.unidad)
                   .Include(x => x.entradas)
                   .Include(x => x.salidas)
                   .FirstOrDefault();

            TipoSalidaMaterial unTipoSalida = db.tipoSalida.Find(unaSalida.idTipoSalidaMaterial);

            try
            {
                SalidaMaterial nuevaSalida = new SalidaMaterial()
                {
                    fecha = DateTime.Now,
                    material = unMaterial,
                    codigoMaterial = unMaterial.codigo,
                    codigoDocumento = unaSalida.codigoDocumento,
                    cantidad = unaSalida.cantidad,
                    tipoSalidaMaterial = unTipoSalida,

                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress
                };

                if (nuevaSalida.HayStock())
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
                return RedirectToAction("Error500", "Error");
            }
            ViewBag.Result = 0;
            cargarTipoSalida();
            return View("Restar");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public ActionResult HistorialIngresos()
        {
            return View("HistorialIngresos");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public JsonResult GetHistorialEgresos()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();

            var historialEgresos = from egr in db.salidas
                                   select new
                                   {
                                       numero = egr.idSalidaMaterial,
                                       codMaterial = egr.codigoMaterial,
                                       material = egr.material.nombre,
                                       cantidad = egr.cantidad,
                                       tipoSalida = egr.tipoSalidaMaterial.nombre,
                                       codDocumento = egr.codigoDocumento,
                                       usuario = egr.LAST_UPDATED_BY,
                                       timestamp = egr.LAST_UPDATED_DATE
                                   };

            return Json(new { Response = historialEgresos }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public ActionResult HistorialEgresos()
        {
            return View("HistorialEgresos");
        }

        [Authorize(Roles = "administrador, deposito, compras")]
        [HttpGet]
        public JsonResult GetHistorialIngresos()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();

            var historialIngresos = from ing in db.entradas
                                    select new
                                    {
                                        numero = ing.idEntradaMaterial,
                                        codMaterial = ing.codigoMaterial,
                                        material = ing.material.nombre,
                                        cantidad = ing.cantidad,
                                        tipoEntrada = ing.tipoEntradaMaterial.nombre,
                                        codDocumento = ing.codigoDocumento,
                                        usuario = ing.LAST_UPDATED_BY,
                                        timestamp = ing.LAST_UPDATED_DATE
                                    };

            return Json(new { Name = "/GetHistorialIngresos", Response = historialIngresos, Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

        private void cargarTipoSalida(object selectedTipoSalida = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(db.tipoSalida.ToList(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(db.tipoSalida.Where(x => x.idSector == 1).ToList(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
            if (User.IsInRole("compras"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(db.tipoSalida.Where(x => x.idSector == 0).ToList(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(db.tipoEntrada.ToList(), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(db.tipoEntrada.Where(x => x.idSector == 1).ToList(), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
            if (User.IsInRole("compras"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(db.tipoEntrada.Where(x => x.idSector == 0).ToList(), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
        }
    }
}