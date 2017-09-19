using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Controllers
{
    public class MaterialController : Controller
    {
        OtContext db = new OtContext();
        
        // GET: Material
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Material/Sumar
        [Route("/Material/Sumar")]
        public ActionResult Sumar()
        {
            return View();
        }
        
        // GET: Material/Restar
        public ActionResult Restar()
        {
            return View();
        }
        
        // GET: Material/Agregar
        public ActionResult Alta()
        {
            cargarProveedor();

            cargarUnidad();

            cargarTipoMaterial();

            return View();
        }

        private void cargarTipoMaterial(object selectedTipoMaterial = null)
        {
            ViewBag.TipoMaterial_Id = new SelectList(db.TipoMaterial.ToList(), "idTipoMaterial", "nombre", selectedTipoMaterial);
        }

        private void cargarProveedor(object selectedProveedor = null)
        {
            ViewBag.Proveedor_Id = new SelectList(db.Proveedor.ToList(), "idProveedor", "nombre", selectedProveedor);
        }

        private void cargarUnidad(object selectedUnidad = null)
        {
            ViewBag.Unidad_Id = new SelectList(db.Unidad.ToList(), "idUnidad", "nombre", selectedUnidad);
        }
        
        //POST: Material/Agregar
        [HttpPost]
        public ActionResult Alta(Material unMaterial)
        {
            try
            {
                Unidad u = db.Unidad.Find(unMaterial.Unidad_Id);
                Proveedor p = db.Proveedor.Find(unMaterial.Proveedor_Id);
                TipoMaterial tm = db.TipoMaterial.Find(unMaterial.TipoMaterial_Id);

                db.Material.Add(new Material
                {
                    codigo = unMaterial.codigo,
                    nombre = unMaterial.nombre,
                    stockMinimo = unMaterial.stockMinimo,
                    detalle = unMaterial.detalle,
                    Unidad_Id = u.idUnidad,
                    Proveedor_Id = p.idProveedor,
                    TipoMaterial_Id = tm.idTipoMaterial,
                    //Unidad = nuevaUnidad,
                    //Proveedor = nuevoProveedor,
                    //TipoMaterial = tipo
                });

                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Alta", "Material");
        }

        //POST: Material/Sumar
        [HttpPost]
        public ActionResult Sumar(Material unMaterial, int sumaActual)
        {
            try
            {
                unMaterial.stockActual = unMaterial.stockActual + sumaActual;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Sumar", "Material");
        }

        //POST: Material/Restar
        [HttpPost]
        public ActionResult Restar(Material unMaterial, int restaActual)
        {
            try
            {
                unMaterial.stockActual = unMaterial.stockActual - restaActual;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Material");
            }

            return RedirectToAction("Restar", "Material");
        }

        //GET: Materiales/Editar/1
        public ActionResult Editar(int id)
        {

            cargarProveedor();

            cargarUnidad();


            Material materialSeleccionado;

            try
            {
                materialSeleccionado = db.Material.Find(id);
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return View(materialSeleccionado);
        }
      
        //POST: Material/Editar/1
        [HttpPost]
        public ActionResult Editar(int id, Material unMaterial)
        {
            Material nuevoMaterial = db.Material.Find(id);
            
            try
            {
                nuevoMaterial.nombre = unMaterial.nombre;
                nuevoMaterial.codigo = unMaterial.codigo;
                nuevoMaterial.Unidad = db.Unidad.Find(unMaterial.Unidad_Id);
                nuevoMaterial.stockMinimo = unMaterial.stockMinimo;
                nuevoMaterial.Proveedor = db.Proveedor.Find(unMaterial.Proveedor_Id);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return RedirectToAction("Buscar", "Material");
        }
        // GET: Material/Buscar

        public ViewResult Buscar(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.nombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_asc" : "";
            //ViewBag.nombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            //searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<Material> staff = db.Material.Where(x => x.habilitado == true).Take(20).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //TODO: Que ???
                staff = db.Material.Where(s => s.nombre.Contains(searchString.ToUpper()) && s.habilitado == true).ToList();
            }

            switch (sortOrder)
            {
                case "nombre_asc":
                    staff = staff.OrderBy(s => s.nombre).ToList();
                    break;
                default:
                    staff = staff.OrderByDescending(s => s.nombre).ToList();
                    break;
            }

            return View(staff.ToList());
        }

        //POST: Material/Borrar/1
        public ActionResult Borrar(int id)
        {
            Material nuevoMaterial = db.Material.Find(id);

            try
            {
                //db.Material.Remove(nuevoMaterial);
                nuevoMaterial.habilitado = false;
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Buscar", "Material");
            }

            return RedirectToAction("Buscar", "Material");
        }
    }

}