using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using gestionmateriales.Repository.Contracts;
using gestionmateriales.Repository.Implementation;

namespace gestionmateriales.Controllers
{
    [Authorize(Roles = "administrador, oficinatecnica, deposito, compras")]
    [Route("/Material")]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository materialRepository;
        private readonly IProveedorRepository proveedorRepository;
        private readonly ITipoMaterialRepository tipoMaterialRepository;
        private readonly IUnidadRepository unidadRepository;
        private readonly IOrdenTrabajoAplicacionRepository ordenTrabajoAplicacionRepository;

        public MaterialController()
        {
            OficinaTecnicaEntities context = new OficinaTecnicaEntities();
            materialRepository = new MaterialRepository(context);
            proveedorRepository = new ProveedorRepository(context);
            unidadRepository = new UnidadRepository(context);
            tipoMaterialRepository = new TipoMaterialRepository(context);
            ordenTrabajoAplicacionRepository = new OrdenTrabajoAplicacionRepository(context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            cargarCombos();

            return View("Agregar");
        }

        [HttpPost]
        public ActionResult Agregar(Material unMaterial)
        {
            if (materialRepository.FindAll().Any(x => x.codigo == unMaterial.codigo && x.hab))
            {
                ViewBag.Result = 1;

                cargarCombos();

                return View("Agregar", unMaterial);
            }

            Unidad unidad = unidadRepository.FindById(unMaterial.idUnidad);

            if (unidad == null) throw new Exception("No existe la unidad");

            Proveedor proveedor = proveedorRepository.FindById(unMaterial.idProveedor);

            if (proveedor == null) throw new Exception("No existe el proveedor");

            TipoMaterial tipoMaterial = tipoMaterialRepository.FindById(unMaterial.idTipoMaterial);

            if (tipoMaterial == null) throw new Exception("No existe el tipo material");

            try
            {
                materialRepository.Add(new Material
                {
                    codigo = unMaterial.codigo,
                    nombre = unMaterial.nombre,
                    stockActual = unMaterial.stockActual,
                    stockMinimo = unMaterial.stockMinimo,
                    detalle = unMaterial.detalle,
                    unidad = unidad,
                    proveedor = proveedor,
                    tipoMaterial = tipoMaterial,
                    CREATED_BY = User.Identity.Name,
                    CREATION_DATE = DateTime.Now,
                    CREATION_IP = Request.UserHostAddress,
                    LAST_UPDATED_BY = User.Identity.Name,
                    LAST_UPDATED_DATE = DateTime.Now,
                    LAST_UPDATED_IP = Request.UserHostAddress
                });
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            cargarCombos();

            ViewBag.Result = 0;

            return View("Agregar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Material material = materialRepository.FindById(id);

            cargarProveedor(material.proveedor.idProveedor);

            cargarUnidad(material.unidad.idUnidad); 

            cargarTipoMaterial(material.tipoMaterial.idTipoMaterial);

            return View("Editar", material);
        }

        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            Material material = materialRepository.FindById(id);

            if (material == null) throw new Exception("No existe el material");

            if (materialRepository.Find(x => x.idMaterial != id && x.hab).Any(y => y.codigo == material.codigo))
            {
                ViewBag.Result = 1;

                cargarProveedor(material.idProveedor);

                cargarUnidad(material.idUnidad);

                cargarTipoMaterial(material.idTipoMaterial);

                return View("Editar", material);
            }

            Unidad unidad = unidadRepository.FindById(unMaterial.idUnidad);

            if (unidad == null) throw new Exception("No existe la unidad");

            Proveedor proveedor = proveedorRepository.FindById(unMaterial.idProveedor);

            if (proveedor == null) throw new Exception("No existe el proveedor");

            TipoMaterial tipoMaterial = tipoMaterialRepository.FindById(unMaterial.idTipoMaterial);

            if (tipoMaterial == null) throw new Exception("No existe el tipo material");

            try
            {
                material.nombre = unMaterial.nombre;

                material.codigo = unMaterial.codigo;

                material.unidad = unidad;

                material.stockMinimo = unMaterial.stockMinimo;

                material.stockActual = unMaterial.stockActual;

                material.proveedor = proveedor;

                material.tipoMaterial = tipoMaterial;

                material.detalle = unMaterial.detalle;

                material.LAST_UPDATED_BY = User.Identity.Name;

                material.LAST_UPDATED_DATE = DateTime.Now;

                material.LAST_UPDATED_IP = Request.UserHostAddress;

                materialRepository.Edit(material);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            cargarProveedor(material.proveedor.idProveedor);

            cargarUnidad(material.unidad.idUnidad);

            cargarTipoMaterial(material.tipoMaterial.idTipoMaterial);

            ViewBag.Result = 0;

            return View("Editar", material);
        }

        public ActionResult Borrar(int id)
        {
            Material material = materialRepository.FindById(id);

            if (material == null) throw new Exception("No existe el material");

            try
            {
                material.hab = false;

                material.LAST_UPDATED_BY = User.Identity.Name;

                material.LAST_UPDATED_DATE = DateTime.Now;

                material.LAST_UPDATED_IP = Request.UserHostAddress;

                materialRepository.Remove(material);
            }
            catch
            {
                return RedirectToAction("Error500", "Error");
            }

            return RedirectToAction("Index", "Material");
        }

        [HttpGet]
        public ActionResult Historial(int id)
        {
            var ordenesTrabajoAplicacion = ordenTrabajoAplicacionRepository.Find(x => x.hab);

            var material = materialRepository.FindById(id);

            ViewData["codigo"] = material.codigo;

            ViewData["nombre"] = material.nombre;

            return View("Historial", ordenesTrabajoAplicacion);
        }

        private void cargarTipoMaterial(object selectedTipoMaterial = null)
        {
            ViewBag.idTipoMaterial = new SelectList(tipoMaterialRepository.FindAll(), "idTipoMaterial", "nombre", selectedTipoMaterial);
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            ViewBag.idProveedor = new SelectList(proveedorRepository.Find(x => x.hab), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            ViewBag.idUnidad = new SelectList(unidadRepository.FindAll(), "idUnidad", "nombre", selectedUnidad);
        }

        private void cargarCombos()
        {
            cargarProveedor();

            cargarUnidad();

            cargarTipoMaterial();
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var material = materialRepository.Find(x => x.hab && x.idMaterial == id)
                .Select(x => new { x.idMaterial, x.codigo, x.nombre, x.stockActual, x.stockMinimo, x.detalle, unidad = x.unidad.nombre,
                    proveedor = x.proveedor.nombre, tipoMaterial = x.tipoMaterial.nombre });

            return Json(new { Response = material }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAll()
        {            
            var materiales = materialRepository.Find(x => x.hab).Select(x => new { x.idMaterial, x.codigo, x.nombre, x.stockActual, x.stockMinimo });

            return Json(new { Response = materiales }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMaterialesShort()
        {

            var materiales = materialRepository.Find(x => x.hab).Select(x => new { x.idMaterial, x.codigo, x.nombre, x.stockActual });

            return Json(new { Response = materiales }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLastUpdated()
        {
            var fecha = materialRepository.Find(x => x.hab).OrderBy(x => x.LAST_UPDATED_DATE).Take(1).Select(x => new { x.LAST_UPDATED_DATE });

            return Json(new { Response = fecha }, JsonRequestBehavior.AllowGet);
        }
    }
}