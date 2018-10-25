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
using gestionmateriales.Models.OficinaTecnica.Documentos;

namespace gestionmateriales.Controllers
{
    [Authorize(Roles = "administrador, oficinatecnica, deposito, compras")]
    [Route("/Stock")]
    public class StockController : Controller
    {
        private readonly ISalidaMaterialRepository salidaMaterialRepository;
        private readonly IEntradaMaterialRepository entradaMaterialRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly ITipoEntradaMaterialRepository tipoEntradaMaterialRepository;
        private readonly ITipoSalidaMaterialRepository tipoSalidaMaterialRepository;
        private readonly IOrdenCompraRepository ordenCompraRepository;
        private readonly IOrdenTrabajoAplicacionRepository ordenTrabajoAplicacionRepository;
        private readonly IOrdenTrabajoRepository ordenTrabajoRepository;

        public StockController()
        {
            OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            entradaMaterialRepository = new EntradaMaterialRepository(context);
            salidaMaterialRepository = new SalidaMaterialRepository(context);
            materialRepository = new MaterialRepository(context);
            tipoEntradaMaterialRepository = new TipoEntradaMaterialRepository(context);
            tipoSalidaMaterialRepository = new TipoSalidaMaterialRepository(context);
            ordenCompraRepository = new OrdenCompraRepository(context);
            ordenTrabajoAplicacionRepository = new OrdenTrabajoAplicacionRepository(context);
            ordenTrabajoRepository = new OrdenTrabajoRepository(context);
        }
        
        [HttpGet]
        public ActionResult Sumar()
        {
            cargarTipoEntrada();

            return View("Sumar");
        }

        [HttpPost]
        public ActionResult Sumar(EntradaMaterial unaEntrada)
        {
            var unMaterial = materialRepository.FindOne(x => x.codigo == unaEntrada.codigoMaterial && x.hab);

            if (unMaterial == null) throw new Exception("No existe el material");

            TipoEntradaMaterial unTipoEntrada = tipoEntradaMaterialRepository.FindById(unaEntrada.idTipoEntradaMaterial);

            if (unTipoEntrada == null) throw new Exception("No existe el tipo entrada material");

            if (!verificarMaterialenDocumento(unMaterial, unaEntrada)) throw new Exception("No se puede verificar el material en el documento");

            try
            {
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

                entradaMaterialRepository.Add(nuevaEntrada);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }
            ViewBag.Result = 0;

            cargarTipoEntrada();

            return View("Sumar");
        }

        private bool verificarMaterialenDocumento(Material unMaterial, EntradaMaterial unaEntrada)
        {
            int documento = Convert.ToInt32(unaEntrada.codigoDocumento);

            switch (unaEntrada.idTipoEntradaMaterial)
            {
                // Orden de Compra
                case 3:
                    {
                        OrdenCompra oc = ordenCompraRepository.FindOne(x => x.numeroInterno == documento);
                        return oc.itemsOC.Any(x => x.material.idMaterial == unMaterial.idMaterial);
                    }
                case 4:
                    {
                        OrdenTrabajoAplicacion ota = ordenTrabajoAplicacionRepository.FindOne(x => x.numero == documento);
                        return ota.itemsOTA.Any(x => x.material.idMaterial == unMaterial.idMaterial);
                    }
                case 8:
                    {
                        OrdenTrabajo ot = ordenTrabajoRepository.FindOne(x => x.numero == documento);
                        return ot.itemsOT.Any(x => x.material.idMaterial == unMaterial.idMaterial);
                    }
            }
            return false;
        }

        [HttpGet]
        public ActionResult Restar()
        {
            cargarTipoSalida();

            return View("Restar");
        }

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

        [HttpGet]
        public ActionResult HistorialIngresos()
        {
            return View("HistorialIngresos");
        }

        [HttpGet]
        public JsonResult GetHistorialEgresos()
        {
            var historialEgresos = from egr in salidaMaterialRepository.FindAll()
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

        [HttpGet]
        public ActionResult HistorialEgresos()
        {
            return View("HistorialEgresos");
        }

        [HttpGet]
        public JsonResult GetHistorialIngresos()
        {
            var historialIngresos = from ing in entradaMaterialRepository.FindAll()
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
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(tipoSalidaMaterialRepository.FindAll(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
            if (User.IsInRole("oficinatecnica"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(tipoSalidaMaterialRepository.FindAll().OrderBy(x => x.nombre), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoSalidaMaterial = new SelectList(tipoSalidaMaterialRepository.Find(x => x.sector.idSector == 2).OrderBy(x => x.nombre).ToList(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
            //if (User.IsInRole("compras"))
            //    ViewBag.IdTipoSalidaMaterial = new SelectList(db.tipoSalida.Where(x => x.sector.idSector == 0).ToList(), "idTipoSalidaMaterial", "nombre", selectedTipoSalida);
        }

        private void cargarTipoEntrada(object selectedTipoEntrada = null)
        {
            if (User.IsInRole("administrador"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(tipoEntradaMaterialRepository.FindAll(), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
            if (User.IsInRole("oficinatecnica"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(tipoEntradaMaterialRepository.Find(x => x.sector.idSector == 1).OrderBy(x => x.nombre), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
            if (User.IsInRole("deposito"))
                ViewBag.IdTipoEntradaMaterial = new SelectList(tipoEntradaMaterialRepository.Find(x => x.sector.idSector == 2).OrderBy(x => x.nombre), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
            //if (User.IsInRole("compras"))
            //    ViewBag.IdTipoEntradaMaterial = new SelectList(db.tipoEntrada.Where(x => x.idSector == ).ToList(), "idTipoEntradaMaterial", "nombre", selectedTipoEntrada);
        }
    }
}