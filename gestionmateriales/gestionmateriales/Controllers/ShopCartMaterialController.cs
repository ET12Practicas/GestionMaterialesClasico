using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class ShopCartMaterialController : Controller
    {
        // GET: ShopCartMaterial
        public ActionResult Index(int id)
        {            
            List<ItemOT> itemsMateriales;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                int cantMat;
                itemsMateriales = new List<ItemOT>();
                OrdenTrabajo ot = db.ordenTrabajo.Find(id);
                var items = db.ItemOT.Where(x => x.idOrdenTrabajo == id).ToList();
                foreach (Material mat in db.materiales.Where(x => x.hab))
                {
                    cantMat = getCantidadByIdMaterial(items, mat.idMaterial);
                    itemsMateriales.Add(new ItemOT { idOrdenTrabajo = ot.idOrdenTrabajo, ordenTrabajo = ot, idMaterial = mat.idMaterial, material = mat, cantidad = cantMat });
                }
            }
            ViewData["idOt"] = id;
            return View(itemsMateriales);
        }

        private int getCantidadByIdMaterial(List<ItemOT> items, int idMaterial)
        {
            ItemOT item = items.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
            if (item != null)
            {
                return item.cantidad;
            }
            return 0;
        }

        //POST: ShopCartMaterial/Agregar/2
        public ActionResult AddToCart(int idOt, int idMaterial, int itemCantidad)
        {            
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                OrdenTrabajo ot = db.ordenTrabajo.Find(idOt);
                Material mat = db.materiales.Find(idMaterial);
                if (!ot.itemsOT.Any(x => x.idMaterial == idMaterial))
                {
                    ot.itemsOT.Add(new ItemOT { idOrdenTrabajo = ot.idOrdenTrabajo, ordenTrabajo = ot, idMaterial = idMaterial, material = mat, cantidad = itemCantidad });
                }
                else
                {
                    ItemOT item = ot.itemsOT.Where(x => x.idMaterial == idMaterial).FirstOrDefault();
                    if (item != null)
                    {
                        item.cantidad = itemCantidad;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }

        public ActionResult Generar()
        {
            return RedirectToAction("Index", "OrdenTrabajo");
        }
    }
}