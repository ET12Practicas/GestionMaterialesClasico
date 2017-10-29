using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;


namespace gestionmateriales.Controllers
{
    public class ProveedorController : Controller
    {
        //TODO refactor con using o otra capa
        OficinaTecnicaEntities db = new OficinaTecnicaEntities();
        
        // GET: Proveedor
        [Route("/Proveedor")]
        public ActionResult Index()
        {
            List<Proveedor> proveedores = db.proveedores.Where(x => x.hab).ToList();

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
                //TODO mejorar
                db.proveedores.Add(new Proveedor { nombre = unProveedor.nombre, cuit = unProveedor.cuit, razonSocial = unProveedor.razonSocial,
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
                proveedorSeleccionado = db.proveedores.Find(id);
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
            Proveedor nuevoProveedor = db.proveedores.Find(id);
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
            Proveedor proveedorSeleccionado = db.proveedores.Find(id);

            try
            {
                proveedorSeleccionado.hab = false;
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
