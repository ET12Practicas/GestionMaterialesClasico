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
        OtContext db = new OtContext();
        
        // GET: ShopCartMaterial
        public ActionResult Index(int id)
        {
            //List<Material> materiales = db.Material.Where(x => x.habilitado).ToList();
            
            List<ItemOT> itemsMateriales = new List<ItemOT>();
            foreach (Material item in db.Material.Where(x => x.habilitado))
            {
                itemsMateriales.Add(new ItemOT {material = item});
            }

            ViewData["idOt"] = id;
            return View(itemsMateriales);
        }

        //POST: ShopCartMaterial/Agregar/2
        [HttpPost]
        //public ActionResult AddToCart(int idOt, int idMaterial, int itemCantidad)
        public ActionResult AddToCart(int idOt, int idMat, ItemOT item)
        {
            //OrdenTrabajo ot = db.OrdenTrabajo.Find(idOt);
            //Material m = db.Material.Find(item.material.idMaterial);
            //try
            //{
            //    ot.ItemOT.Add(new ItemOT { material = m, cantidad = item.cantidad });
            //    db.SaveChanges();
            //}
            //catch
            //{
            //    return RedirectToAction("index", "Home");
            //}

            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOt });
        }
    }
}