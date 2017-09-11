using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class PedidosController : Controller
    {
        OtContext db = new OtContext();

        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }
       
        // GET: Pedido/Agregar
        public ActionResult Agregar()
        {
            return View();
        }
      
        //POST: Pedido/1/Agregar
        [HttpPost]
        public ActionResult Agregar(Pedido unPedido)
        {
            try
            {
                db.Pedido.Add(new Pedido { nroPedido = unPedido.nroPedido, nroOrdenDeTrabajo = unPedido.nroOrdenDeTrabajo, destino = unPedido.destino });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Pedidos");
            }

            return RedirectToAction("Agregar", "Pedidos");
        }
     
        //GET: Pedidos/Editar/1
        public ActionResult Editar(int id)
        {
            Pedido pedidoSeleccionado;

            try
            {
                pedidoSeleccionado = db.Pedido.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Pedidos");
            }

            return View(pedidoSeleccionado);
        }

        //POST: Personal/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Pedido unPedido)
        {
            Pedido nuevoPedido = db.Pedido.Find(id);
            
            try
            {
                nuevoPedido.nroPedido = unPedido.nroPedido;
                nuevoPedido.nroOrdenDeTrabajo = unPedido.nroOrdenDeTrabajo;
                nuevoPedido.destino = unPedido.destino;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Pedidos");
            }

            return RedirectToAction("Buscar", "Pedidos");
        }
       
        // GET: Pedido/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.nroPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroPedido_asc" : "";
            ViewBag.nroPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroPedido_desc" : "";
            ViewBag.nroOrdenDeTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenDeTrabajo_asc" : "";
            ViewBag.nroOrdenDeTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenDeTrabajo_desc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<Pedido> staff = db.Pedido.Where(x => x.habilitado == true).Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //TODO
                staff = db.Pedido.Where(s => (s.nroPedido.ToString().Contains(searchString.ToUpper()) || s.nroOrdenDeTrabajo.ToString().Contains(searchString.ToUpper())) && s.habilitado == true).ToList();
            }

            switch (sortOrder)
            {
                case "nroPedido_asc":
                    staff = staff.OrderBy(s => s.nroPedido).ToList();
                    break;
                case "nroPedido_desc":
                    staff = staff.OrderByDescending(s => s.nroPedido).ToList();
                    break;
                case "nroOrdenDeTrabajo_asc":
                    staff = staff.OrderBy(s => s.nroOrdenDeTrabajo).ToList();
                    break;
                case "nroOrdenDeTrabajo_desc":
                    staff = staff.OrderByDescending(s => s.nroOrdenDeTrabajo).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        //POST: Pedido/Borrar/1
        public ActionResult Borrar(int id)
        {
            Pedido pedidoSeleccionado = db.Pedido.Find(id);

            try
            {
                // db.Personal.Remove(personalSeleccionado);
                pedidoSeleccionado.habilitado = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Pedidos");
            }

            return RedirectToAction("Buscar", "Pedidos");
        }
    }
}