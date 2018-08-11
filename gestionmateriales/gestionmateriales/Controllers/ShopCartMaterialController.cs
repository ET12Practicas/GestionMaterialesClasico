using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class ShopCartMaterialController : Controller
    {
        // GET: ShopCartMaterial
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [HttpGet]
        public ActionResult Index(int id)
        {            
            List<ItemOrdenTrabajoAplicacion> itemsMateriales;
            OrdenTrabajoAplicacion ot;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                int cantMat;
                itemsMateriales = new List<ItemOrdenTrabajoAplicacion>();
                ot = db.ordenTrabajoAplicacion.Find(id);
                var items = db.ItemOTA.Where(x => x.ordenTrabajoAplicacion.idOrdenTrabajoAplicacion == id).ToList();
                foreach (Material mat in db.materiales.Where(x => x.hab))
                {
                    cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                    itemsMateriales.Add(new ItemOrdenTrabajoAplicacion { idOrdenTrabajoAplicacion = ot.idOrdenTrabajoAplicacion, ordenTrabajoAplicacion = ot, idMaterial = mat.idMaterial, material = mat, cantidad = cantMat });
                }
            }
            ViewData["idOt"] = id;
            ViewData["numero"] = ot.numero;
            ViewData["nombre"] = ot.nombre;
            return View(itemsMateriales);
        }

        private int getCantidadByIdMaterial(List<ItemOrdenTrabajoAplicacion> items, int idMaterial)
        {
            ItemOrdenTrabajoAplicacion item = items.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
            if (item != null)
            {
                return item.cantidad;
            }
            return 0;
        }

        //POST: ShopCartMaterial/Agregar/2
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult AddToCart(int idOt, int idMaterial, int itemCantidad)
        {            
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                OrdenTrabajoAplicacion ot = db.ordenTrabajoAplicacion.Find(idOt);
                Material mat = db.materiales.Find(idMaterial);
                if (!ot.itemsOTA.Any(x => x.idMaterial == idMaterial))
                {
                    ot.itemsOTA.Add(new ItemOrdenTrabajoAplicacion { idOrdenTrabajoAplicacion = ot.idOrdenTrabajoAplicacion, ordenTrabajoAplicacion = ot, idMaterial = idMaterial, material = mat, cantidad = itemCantidad });
                }
                else
                {
                    ItemOrdenTrabajoAplicacion item = ot.itemsOTA.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
                    if (item != null)
                    {
                        item.cantidad = itemCantidad;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpGet]
        public ActionResult Generar()
        {
            return RedirectToAction("Index", "OrdenTrabajoAplicacion");
        }
    }
}