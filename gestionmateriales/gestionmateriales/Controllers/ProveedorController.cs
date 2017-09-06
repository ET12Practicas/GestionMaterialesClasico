using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;


namespace gestionmateriales.Controllers
{
    public class ProveedorController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Proveedor/Buscar
        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_asc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<Proveedor> staff = db.Proveedor.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.Proveedor.Where(s => s.nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "nombre_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        // GET: Proveedor/Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        //POST: Proveedor/1/Agregar
        [HttpPost]
        public ActionResult Agregar(Proveedor unProveedor)
        {
            try
            {
                db.Proveedor.Add(new Proveedor { nombre = unProveedor.nombre, direccion = unProveedor.direccion });
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Proveedor");
            }

            return RedirectToAction("Agregar", "Proveedor");
        }

        //GET: Proveedor/Editar/1
        public ActionResult Editar(int id)
        {
            Proveedor proveedorSeleccionado;

            try
            {
                proveedorSeleccionado = db.Proveedor.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Proveedor");
            }

            return View(proveedorSeleccionado);
        }

        //POST: Proveedor/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Proveedor unProveedor)
        {
            Proveedor nuevoProveedor = db.Proveedor.Find(id);
            try
            {
                nuevoProveedor.nombre = unProveedor.nombre;
                nuevoProveedor.direccion = unProveedor.direccion;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Proveedor");
            }

            return RedirectToAction("Buscar", "Proveedor");
        }
    }
}
