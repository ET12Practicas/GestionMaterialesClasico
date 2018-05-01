using gestionmateriales.Models.OficinaTecnica;
using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace gestionmateriales.Controllers
{
    public class ShopCartMaterialPedidoController : Controller
    {
        // GET: ShopCartMaterial
        [Authorize(Roles = "administrador, oficinatecnica, rectoria")]
        [HttpGet]
        public ActionResult Index(int id)
        {
            List<ItemOrdenPedido> itemsMateriales;
            OrdenPedido op;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                int cantMat;
                itemsMateriales = new List<ItemOrdenPedido>();
                op = db.ordenPedido.Find(id);
                var items = db.ItemOP.Where(x => x.idOrdenPedido == id).ToList();
                foreach (Material mat in db.materiales.Where(x => x.hab))
                {
                    cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                    itemsMateriales.Add(new ItemOrdenPedido { idOrdenPedido = op.idOrdenPedido, ordenPedido = op, idMaterial = mat.idMaterial, material = mat, cantidad = cantMat });
                }
            }
            ViewData["idOp"] = id;
            ViewData["numero"] = op.numeroOrdenPedido;
            return View(itemsMateriales);
        }

        private int getCantidadByIdMaterial(List<ItemOrdenPedido> items, int idMaterial)
        {
            ItemOrdenPedido item = items.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
            if (item != null)
            {
                return item.cantidad;
            }
            return 0;
        }

        //POST: ShopCartMaterial/Agregar/2
        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult AddToCart(int idOp, int idMaterial, int itemCantidad)
        {
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                OrdenPedido op = db.ordenPedido.Find(idOp);
                Material mat = db.materiales.Find(idMaterial);
                if (!op.itemsOP.Any(x => x.idMaterial == idMaterial))
                {
                    op.itemsOP.Add(new ItemOrdenPedido { idOrdenPedido = op.idOrdenPedido, ordenPedido = op, idMaterial = idMaterial, material = mat, cantidad = itemCantidad });
                }
                else
                {
                    ItemOrdenPedido item = op.itemsOP.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
                    if (item != null)
                    {
                        item.cantidad = itemCantidad;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "ShopCartMaterialPedido", new { id = idOp });
        }

        [Authorize(Roles = "administrador, oficinatecnica")]
        public ActionResult Generar()
        {
            return RedirectToAction("Index", "OrdenPedido");
        }
    }
}