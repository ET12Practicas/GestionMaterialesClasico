using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class OrdenPedidoController : Controller
    {
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();

        // GET: OrdenPedido
        [Route("/OrdenPedido")]
        public ActionResult Index()
        {
            List<OrdenPedido> pedidos = db.ordenPedido.Where(x => x.hab).ToList();
            return View(pedidos);
        }

        // GET: OrdenPedido/Agregar
        [Route("/OrdenPedido/Agregar")]
        public ActionResult Agregar()
        {
            cargarNumOT();
            return View();
        }

        //POST: OrdenPedido/1/Agregar
        [HttpPost]
        public ActionResult Agregar(OrdenPedido aOP)
        {
            int idOp = -1;

            if(db.ordenPedido.Any(x=> x.numOp == aOP.numOp))
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            try
            {
                db.ordenPedido.Add(new OrdenPedido(aOP.numOp, aOP.numOt, aOP.destino, aOP.fecha));
                db.SaveChanges();

                idOp = db.ordenPedido.SingleOrDefault(x => x.numOp == aOP.numOp).idOrdenPedido;
            }
            catch
            {
                return RedirectToAction("Index", "OrdenPedido");
            }

            if (idOp < 0)
            {
                return RedirectToAction("Index", "OrdenPedido");
            }

            return RedirectToAction("Index", "ShopCartMaterialPedido", new { id = idOp });
        }

        //GET: OrdenPedido/Editar/1
        [Route("/OrdenPedido/Editar/{id}")]
        public ActionResult Editar(int id)
        {
            OrdenPedido ordenSelect = db.ordenPedido.Find(id);
            cargarNumOT(ordenSelect.numOt);
            return View(ordenSelect);
        }

        //POST: OrdenPedido/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, OrdenPedido aOP)
        {
            int idOp = -1;
            OrdenPedido opEdit = db.ordenPedido.Find(id);
            
            try
            {
                opEdit.numOp = aOP.numOp;
                opEdit.numOt = aOP.numOt;
                opEdit.destino = aOP.destino;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error406", "Error");
            }

            idOp = opEdit.idOrdenPedido;

            if (idOp < 0)
            {
                return RedirectToAction("Error406", "Error");
            }

            return RedirectToAction("Index","ShopCartMaterialPedido", new { id = idOp});
        }

        //POST: Pedido/Borrar/1
        public ActionResult Borrar(int id)
        {
            OrdenPedido pedidoSeleccionado = db.ordenPedido.Find(id);

            try
            {
                pedidoSeleccionado.hab = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "OrdenPedido");
            }

            return RedirectToAction("Index", "OrdenPedido");
        }

        private void cargarNumOT(object selectedNumOT = null)
        {
            ViewBag.idNumOt = new SelectList(db.ordenTrabajo.Where(x => x.hab).ToList(), "idTrabajo", "numero", selectedNumOT);
        }
    }
}