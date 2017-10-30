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
            //cargarDestino();
            //cargarNumOT();
            //cargarNumOP();
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
                db.ordenPedido.Add(new OrdenPedido {numOp = aOP.numOp, numOt = aOP.numOt, destino = aOP.destino });
                db.SaveChanges();

                idOp = db.ordenPedido.SingleOrDefault(x => x.numOp == aOP.numOp).idOrdenPedido;
            }
            catch
            {
                return RedirectToAction("Index", "OrdenPedido");
            }

            if (idOp < 0)
            {
                return RedirectToAction("Index", "OrdenTrabajo");
            }

            return RedirectToAction("Index", "ShopCartMaterial", new { id = idOp });
        }

        //GET: OrdenPedido/Editar/1
        [Route("/OrdenPedido/Editar/{id}")]
        public ActionResult Editar(int id)
        {
            OrdenPedido pedidoSeleccionado;

            try
            {
                pedidoSeleccionado = db.ordenPedido.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "OrdenPedido");
            }

            return View(pedidoSeleccionado);
        }

        //POST: OrdenPedido/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, OrdenPedido unPedido)
        {
            OrdenPedido nuevoPedido = db.ordenPedido.Find(id);
            
            try
            {
                nuevoPedido.numOp = unPedido.numOp;
                nuevoPedido.numOt = unPedido.numOt;
                nuevoPedido.destino = unPedido.destino;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "OrdenPedido");
            }

            ViewBag.Result = true;

            return View("Editar", nuevoPedido);
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

        //private void cargarNumOP(object selectedNumOP = null)
        //{
        //    ViewBag.idNumOp = new SelectList(db.ordenPedido.Where(x => x.hab).ToList(), "idPedido", "numero", selectedNumOP);
        //}

        //private void cargarNumOT(object selectedNumOT = null)
        //{
        //    ViewBag.idNumOt = new SelectList(db.ordenTrabajo.Where(x => x.hab).ToList(), "idTrabajo", "numero", selectedNumOT);
        //}

        //private void cargarDestino(object selectedDestino = null)
        //{
        //    ViewBag.idDestino = new SelectList(db.ordenPedido.Where(x => x.hab).ToList(), "idDestino", "destino", selectedDestino);
        //}
    }
}