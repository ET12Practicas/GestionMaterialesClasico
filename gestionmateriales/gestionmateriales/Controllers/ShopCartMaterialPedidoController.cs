using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;


namespace gestionmateriales.Controllers
{
    public class ShopCartMaterialPedidoController : Controller
    {
        // GET: ShopCartMaterial
        public ActionResult Index(int id)
        {
            List<ItemOP> itemsMateriales;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                int cantMat;
                itemsMateriales = new List<ItemOP>();
                OrdenPedido op = db.ordenPedido.Find(id);
                var items = db.ItemOP.Where(x => x.idOrdenPedido == id).ToList();
                foreach (Material mat in db.materiales.Where(x => x.hab))
                {
                    cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                    itemsMateriales.Add(new ItemOP { idOrdenPedido = op.idOrdenPedido, ordenPedido = op, idMaterial = mat.idMaterial, material = mat, cantidad = cantMat });
                }
            }
            ViewData["idOp"] = id;
            return View(itemsMateriales);
        }

        private int getCantidadByIdMaterial(List<ItemOP> items, int idMaterial)
        {
            ItemOP item = items.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
            if (item != null)
            {
                return item.cantidad;
            }
            return 0;
        }

        //POST: ShopCartMaterial/Agregar/2
        public ActionResult AddToCart(int idOp, int idMaterial, int itemCantidad)
        {
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                OrdenPedido op = db.ordenPedido.Find(idOp);
                Material mat = db.materiales.Find(idMaterial);
                if (!op.itemsOP.Any(x => x.idMaterial == idMaterial))
                {
                    op.itemsOP.Add(new ItemOP { idOrdenPedido = op.idOrdenPedido, ordenPedido = op, idMaterial = idMaterial, material = mat, cantidad = itemCantidad });
                }
                else
                {
                    ItemOP item = op.itemsOP.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
                    if (item != null)
                    {
                        item.cantidad = itemCantidad;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "ShopCartMaterialPedido", new { id = idOp });
        }

        public ActionResult Generar()
        {
            return RedirectToAction("Index", "OrdenPedido");
        }
    }
}