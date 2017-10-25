using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class OrdenPedidoController : Controller
    {
        OtContext db = new OtContext();

        // GET: OrdenPedido
        [Route("/OrdenPedido")]
        public ActionResult Index()
        {
            List<OrdenPedido> pedidos = db.OrdenPedido.Where(x => x.habilitado == true).ToList();

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
                db.OrdenPedido.Add(unPedido); 
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
                pedidoSeleccionado = db.OrdenPedido.Find(id);
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
            OrdenPedido nuevoPedido = db.OrdenPedido.Find(id);
            
            try
            {
                nuevoPedido.nroOrdenPedido = unPedido.nroOrdenPedido;
                nuevoPedido.nroOrdenTrabajo = unPedido.nroOrdenTrabajo;
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
            OrdenPedido pedidoSeleccionado = db.OrdenPedido.Find(id);

            try
            {
                pedidoSeleccionado.habilitado = false;
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