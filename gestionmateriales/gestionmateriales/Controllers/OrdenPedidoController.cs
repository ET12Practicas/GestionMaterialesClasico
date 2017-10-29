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
            return View();
        }

        //POST: OrdenPedido/1/Agregar
        [HttpPost]
        public ActionResult Agregar(OrdenPedido unPedido)
        {
            try
            {
                db.ordenPedido.Add(unPedido); 
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "OrdenPedido");
            }
            ViewBag.Result = true;
            return View("Agregar", unPedido);
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
    }
}