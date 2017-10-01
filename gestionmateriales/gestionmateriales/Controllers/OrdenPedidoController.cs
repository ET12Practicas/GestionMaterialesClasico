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

        // GET: Pedidos
        [Route("/OrdenPedido")]
        public ActionResult Index()
        {
            return View();
        }
       
        // GET: Pedido/Agregar
        [Route("/OrdenPedido/Agregar")]
        public ActionResult Agregar()
        {
            return View();
        }
      
        //POST: Pedido/1/Agregar
        [HttpPost]
        public ActionResult Agregar(OrdenPedido unPedido)
        {
            try
            {
                db.OrdenPedido.Add(new OrdenPedido(unPedido.nroOrdenPedido, unPedido.nroOrdenTrabajo, unPedido.destino)); 
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Pedidos");
            }

            return RedirectToAction("Agregar", "Pedidos");
        }
     
        //GET: Pedidos/Editar/1
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
                return RedirectToAction("Buscar", "Pedidos");
            }

            return View(pedidoSeleccionado);
        }

        //POST: Pedido/Editar/1
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
                return RedirectToAction("Buscar", "Pedidos");
            }

            return RedirectToAction("Buscar", "Pedidos");
        }
       
        // GET: Pedido/Buscar
        [Route("/OrdenPedido/Buscar")]
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.nroOrdenPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenPedido_asc" : "";
            ViewBag.nroOrdenPedidoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenPedido_desc" : "";
            ViewBag.nroOrdenTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenTrabajo_asc" : "";
            ViewBag.nroOrdenTrabajoSortParm = String.IsNullOrEmpty(sortOrder) ? "nroOrdenTrabajo_desc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<OrdenPedido> staff = db.OrdenPedido.Where(x => x.habilitado == true).Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.OrdenPedido.Where(s => (s.nroOrdenPedido.ToString().Contains(searchString.ToUpper()) || s.nroOrdenTrabajo.ToString().Contains(searchString.ToUpper())) && s.habilitado == true).ToList();
            }

            switch (sortOrder)
            {
                case "nroOrdenPedido_asc":
                    staff = staff.OrderBy(s => s.nroOrdenPedido).ToList();
                    break;
                case "nroOrdenPedido_desc":
                    staff = staff.OrderByDescending(s => s.nroOrdenPedido).ToList();
                    break;
                case "nroOrdenTrabajo_asc":
                    staff = staff.OrderBy(s => s.nroOrdenTrabajo).ToList();
                    break;
                case "nroOrdenTrabajo_desc":
                    staff = staff.OrderByDescending(s => s.nroOrdenTrabajo).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        //POST: Pedido/Borrar/1
        public ActionResult Borrar(int id)
        {
            OrdenPedido pedidoSeleccionado = db.OrdenPedido.Find(id);

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