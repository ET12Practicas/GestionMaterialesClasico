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
        pp67_gestionmaterialesEntities db = new pp67_gestionmaterialesEntities();
        //ot_gestionmaterialesEntities db = new ot_gestionmaterialesEntities();

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

            List<proveedor> staff = db.proveedor.Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.proveedor.Where(s => s.nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
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
        public ActionResult Agregar(proveedor unProveedor)
        {
            try
            {
                db.proveedor.Add(new proveedor { nombre = unProveedor.nombre, contacto = unProveedor.contacto });
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
            proveedor proveedorSeleccionado;

            try
            {
                proveedorSeleccionado = db.proveedor.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Proveedor");
            }

            return View(proveedorSeleccionado);
        }

        //POST: Proveedor/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, proveedor unProveedor)
        {
            proveedor nuevoProveedor = db.proveedor.Find(id);
            try
            {
                nuevoProveedor.nombre = unProveedor.nombre;
                nuevoProveedor.contacto = unProveedor.contacto;
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
