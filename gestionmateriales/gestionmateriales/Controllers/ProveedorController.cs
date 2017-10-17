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
        [Route("/Proveedor")]
        public ActionResult Index()
        {
            List<Proveedor> proveedores = db.Proveedor.Where(x => x.habilitado).ToList();

            return View(proveedores);
        }

        [Route("/Proveedor/Agregar")]
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

            ViewBag.Result = true;

            return View("Agregar", unProveedor);
        }

        //GET: Proveedor/Editar/1
        [Route("/Proveedor/Editar/{id}")]
        public ActionResult Editar(int id)
        {
            Proveedor proveedorSeleccionado;

            try
            {
                proveedorSeleccionado = db.Proveedor.Find(id);
            }
            catch
            {
                return RedirectToAction("Index", "Proveedor");
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
                return RedirectToAction("Index", "Proveedor");
            }
            
            ViewBag.Result = true;

            return View("Editar", unProveedor);
        }

        //POST: Proveedor/Borrar/1
        public ActionResult Borrar(int id)
        {
            Proveedor proveedorSeleccionado = db.Proveedor.Find(id);

            try
            {
                proveedorSeleccionado.habilitado = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Proveedor");
            }

            return RedirectToAction("Index", "Proveedor");
        }
    }
}
