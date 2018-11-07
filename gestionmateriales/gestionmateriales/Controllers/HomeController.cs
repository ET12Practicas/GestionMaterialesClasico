using System.Web.Mvc;
using System.Linq;
using gestionmateriales.Models;
using System.Collections.Generic;
using gestionmateriales.Models.OficinaTecnica;

namespace gestionmateriales.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Notificacion = 0;
            //if (hayMaterialParaComprar())
            //    ViewBag.Notificacion = 1;
            return View("Index");
        }

        [HttpGet]
        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        private dynamic hayMaterialParaComprar()
        {
            bool notif = false;
            using (OficinaTecnicaEntities db = new OficinaTecnicaEntities())
            {
                notif = db.materiales.Any(y => y.hab && y.stockActual <= y.stockMinimo);
            }
            return notif;
        }

        public ActionResult Menu()
        {
            List<MenuItem> menu = new List<MenuItem>();

            if (User.IsInRole("administrador"))
            {
                menu.Add(new MenuItem { Id = 1, nameOption = "Inicio", controller = "Home", action = "Index", imageClass = "c-blue-500 far fa-home", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 80, nameOption = "Tablero de Control", controller = "Dashboard", action = "Index", imageClass = "c-green-500 far fa-tachometer-alt", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 70, nameOption = "Administración", controller = "", action = "", imageClass = "c-navy-500 far fa-users", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 71, nameOption = "Usuarios", controller = "Administracion", action = "Usuarios", imageClass = "", estatus = true, isParent = false, parentId = 70 });
                menu.Add(new MenuItem { Id = 72, nameOption = "Roles", controller = "Administracion", action = "Roles", imageClass = "", estatus = true, isParent = false, parentId = 70 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Permisos", controller = "Administracion", action = "Permisos", imageClass = "", estatus = true, isParent = false, parentId = 70 });
                menu.Add(new MenuItem { Id = 10, nameOption = "Documentos", controller = "", action = "", imageClass = "c-red-500 far fa-copy", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Trabajo", controller = "OrdenTrabajo", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 12, nameOption = "Orden de Trabajo de Aplicación", controller = "OrdenTrabajoAplicacion", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 13, nameOption = "Orden de Pedido", controller = "OrdenPedido", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 14, nameOption = "Orden de Compra", controller = "OrdenCompra", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "c-deep-purple-500 far fa-sync-alt", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Entrada", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 22, nameOption = "Salida", controller = "Stock", action = "Restar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Entradas", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 24, nameOption = "Historial Salidas", controller = "Stock", action = "HistorialEgresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 30, nameOption = "Compras", controller = "", action = "", imageClass = "c-teal-500 far fa-shopping-cart", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 31, nameOption = "Necesidades", controller = "Compras", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 30 });                
                menu.Add(new MenuItem { Id = 40, nameOption = "Materiales", controller = "Material", action = "Index", imageClass = "c-brown-500 far fa-wrench", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 50, nameOption = "Proveedores", controller = "Proveedor", action = "Index", imageClass = "c-deep-purple-500 far fa-truck", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 60, nameOption = "Personal", controller = "Personal", action = "Index", imageClass = "c-pink-500 far fa-male", estatus = true, isParent = false, parentId = 0 });
            }

            if (User.IsInRole("oficinatecnica"))
            {
                menu.Add(new MenuItem { Id = 1, nameOption = "Inicio", controller = "Home", action = "Index", imageClass = "c-blue-500 far fa-home", estatus = true, isParent = false, parentId = 0 });
                //menu.Add(new MenuItem { Id = 80, nameOption = "Tablero de Control", controller = "Dashboard", action = "Index", imageClass = "c-green-500 far fa-tachometer-alt", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 10, nameOption = "Documentos", controller = "", action = "", imageClass = "c-red-500 far fa-copy", estatus = true, isParent = true, parentId = 0 });
                //menu.Add(new MenuItem { Id = 11, nameOption = "Orden de Trabajo", controller = "OrdenTrabajo", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 12, nameOption = "Orden de Trabajo de Aplicación", controller = "OrdenTrabajoAplicacion", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                //menu.Add(new MenuItem { Id = 13, nameOption = "Orden de Pedido", controller = "OrdenPedido", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 14, nameOption = "Orden de Compra", controller = "OrdenCompra", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 10 });
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "c-deep-purple-500 far fa-sync-alt", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Entrada", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 22, nameOption = "Salida", controller = "Stock", action = "Restar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Entradas", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 24, nameOption = "Historial Salidas", controller = "Stock", action = "HistorialEgresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 30, nameOption = "Compras", controller = "", action = "", imageClass = "c-teal-500 far fa-shopping-cart", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 31, nameOption = "Necesidades", controller = "Compras", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 30 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Materiales", controller = "Material", action = "Index", imageClass = "c-brown-500 far fa-wrench", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 50, nameOption = "Proveedores", controller = "Proveedor", action = "Index", imageClass = "c-deep-purple-500 far fa-truck", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 60, nameOption = "Personal", controller = "Personal", action = "Index", imageClass = "c-pink-500 far fa-male", estatus = true, isParent = false, parentId = 0 });
            }

            if (User.IsInRole("deposito"))
            {
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "c-deep-purple-500 far fa-sync-alt", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Entrada", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 22, nameOption = "Salida", controller = "Stock", action = "Restar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Entradas", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 24, nameOption = "Historial Salidas", controller = "Stock", action = "HistorialEgresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Materiales", controller = "Material", action = "Index", imageClass = "c-brown-500 far fa-wrench", estatus = true, isParent = false, parentId = 0 });
            }

            if (User.IsInRole("compras"))
            {
                menu.Add(new MenuItem { Id = 20, nameOption = "Stock", controller = "", action = "", imageClass = "c-deep-purple-500 far fa-sync-alt", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 21, nameOption = "Entrada", controller = "Stock", action = "Sumar", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 23, nameOption = "Historial Ingreso", controller = "Stock", action = "HistorialIngresos", imageClass = "", estatus = true, isParent = false, parentId = 20 });
                menu.Add(new MenuItem { Id = 30, nameOption = "Compras", controller = "", action = "", imageClass = "c-teal-500 far fa-shopping-cart", estatus = true, isParent = true, parentId = 0 });
                menu.Add(new MenuItem { Id = 31, nameOption = "Necesidades", controller = "Compras", action = "Index", imageClass = "", estatus = true, isParent = false, parentId = 30 });
                menu.Add(new MenuItem { Id = 40, nameOption = "Materiales", controller = "Material", action = "Index", imageClass = "c-brown-500 far fa-wrench", estatus = true, isParent = false, parentId = 0 });
                menu.Add(new MenuItem { Id = 50, nameOption = "Proveedores", controller = "Proveedor", action = "Index", imageClass = "c-deep-purple-500 far fa-truck", estatus = true, isParent = false, parentId = 0 });
            }

            return PartialView("Menu", menu);
        }
    }
}