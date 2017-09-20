using System;
using System.Collections.Generic;
using System.Linq;
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

            List<Proveedor> staff = db.Proveedor.Where(x => x.habilitado == true).Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                staff = db.Proveedor.Where(s => s.nombre.ToUpper().Contains(searchString.ToUpper()) && s.habilitado == true).ToList();
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
                db.Proveedor.Add(new Proveedor { nombre = unProveedor.nombre, cuit = unProveedor.cuit, razonSocial = unProveedor.razonSocial,
                direccion = unProveedor.direccion, horario = unProveedor.horario, telefono = unProveedor.telefono, nombreContacto = unProveedor.nombreContacto});
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
                nuevoProveedor.cuit = unProveedor.cuit;
                nuevoProveedor.razonSocial = unProveedor.razonSocial;
                nuevoProveedor.horario = unProveedor.horario;
                nuevoProveedor.telefono = unProveedor.telefono;
                nuevoProveedor.nombreContacto = unProveedor.nombreContacto;
                nuevoProveedor.direccion = unProveedor.direccion;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Proveedor");
            }

            return RedirectToAction("Buscar", "Proveedor");
        }

        //POST: Proveedor/Borrar/1
        //public ActionResult Borrar(int id)
        //{
        //    Proveedor proveedorSeleccionado = db.Proveedor.Find(id);

        //    try
        //    {
        //        // db.Personal.Remove(personalSeleccionado);
        //        proveedorSeleccionado.habilitado = false;
        //        db.SaveChanges();
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Buscar", "Proveedor");
        //    }

        //    return RedirectToAction("Buscar", "Proveedor");
        //}
    }
}
