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
        [Authorize(Roles = "administrador, oficinatecnica, deposito, rectoria")]
        [Route("/OrdenPedido")]
        [HttpGet]
        public ActionResult Index()
        {
            List<OrdenPedido> pedidos = db.ordenPedido.Where(x => x.hab).ToList();
            return View(pedidos);
        }

        // GET: OrdenPedido/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenPedido/Agregar")]
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: OrdenPedido/1/Agregar
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Agregar(OrdenPedido aOP)
        {
            int idOp = -1;

            if(db.ordenPedido.Any(x=> x.numOp == aOP.numOp))
            {
                ViewBag.Result = 1;
                return View("Agregar", aOP);
            }

            try
            {
                db.ordenPedido.Add(new OrdenPedido(aOP.numOp, aOP.numOta, aOP.destino, aOP.fecha));
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
        [Authorize(Roles = "administrador, oficinatecnica")]
        [Route("/OrdenPedido/Editar/{id}")]
        [HttpGet]
        public ActionResult Editar(int id)
        {
            OrdenPedido ordenSelect = db.ordenPedido.Find(id);
            return View(ordenSelect);
        }

        //POST: OrdenPedido/Editar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
        [HttpPost]
        public ActionResult Editar(int id, OrdenPedido aOP)
        {
            int idOp = -1;
            OrdenPedido opEdit = db.ordenPedido.Find(id);
            if(db.ordenPedido.Where(x => x.idOrdenPedido != id).Any(y => y.numOp == aOP.numOp))
            {
                ViewBag.Result = 1;
                return View("Editar", opEdit);
            }
            try
            {
                opEdit.numOp = aOP.numOp;
                opEdit.numOta = aOP.numOta;
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

            return RedirectToAction("Index","ShopCartMaterialPedido", new { id = idOp });
        }

        //POST: Pedido/Borrar/1
        [Authorize(Roles = "administrador, oficinatecnica")]
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