using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;
using gestionmateriales.Models;

namespace gestionmateriales.Controllers
{
    public class ComprasController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();

        // GET: Compras
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [Route("/Compras")]
        [HttpGet]
        public ActionResult Index()
        {
            OficinaTecnicaEntities db = new OficinaTecnicaEntities();
            List<Material> materiales = db.materiales.Where(x => x.hab && x.stockActual <= x.stockMinimo).ToList();
            return View("Index", materiales);
        }
        
        //GET: AprobarOP
        [Authorize (Roles = "administrador, oficinatecnica")]
        [Route("/AprobarOP")]
        [HttpGet]
        public ActionResult AprobarOP()
        {
            return View();
        }

        //POST: AprobarOP
        [HttpPost]

        public ActionResult AprobarOP(ComprasViewModels compra)
        {
            //TODO: falta implementar el mergeo de los las ordenes de pedido con el stock real
            // es decir que se tiene que contrastar lo que se necesita con lo que hay en deposito
             //var items = from op in db.ordenPedido 
             //            join i in db.ItemOP on op.idOrdenPedido equals i.idOrdenPedido
             //            where op.fecha > compra.fechaInicio && op.fecha < compra.fechaFin
             //            group op by i.idMaterialB into materialGroup
             //            select new {materialGroup., 
             //                        i.cantidad, 
             //                        getStockActualById(i.idMaterial),
             //                        getStockActualById(i.idMaterial) - i.cantidad
             //            };

            return View();                         
        }
    }
}