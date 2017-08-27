using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gestionmateriales.Models.Usuarios;

namespace gestionmateriales.Controllers
{
    public class LoginController : Controller
    {
        OtUsersContext db = new OtUsersContext();

        // GET: Login
        public ActionResult Index()
        {
            //TODO: Borrar usuario de ejemplo
            //try
            //{
            //    Rol unRol = new Rol { Nombre = "Alumno" };
            //    db.Rol.Add(unRol);
            //    db.Rol.Add(new Rol { Nombre = "Rectoría" });
            //    db.Rol.Add(new Rol { Nombre = "Secretaría" });
            //    db.Rol.Add(new Rol { Nombre = "Cooperadora" });
            //    db.Rol.Add(new Rol { Nombre = "Oficina Tecnica" });

            //    Usuario user = new Usuario { Nombre = "alumno", Contrasenia = "tecnica", Rol = unRol };
            //    db.Usuario.Add(user);

            //    db.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    throw new InvalidOperationException();
            //}
            
            cargarRoles();

            return View();
        }

        private void cargarRoles(object selectedRol = null)
        {
            ViewBag.Rol_Id = new SelectList(db.Rol.ToList(), "Id", "Nombre", selectedRol);
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult SingIn(Usuario unUsuario)
        {
            try
            {
                bool res = db.Usuario.Any(x => x.Nombre.Equals(unUsuario.Nombre) &&
                    x.Contrasenia.Equals(unUsuario.Contrasenia) &&
                    x.Rol.Id == unUsuario.Rol_Id);

                if (!res)
                {
                    //TODO: Mostrar pantalla error, ver tipos de errores, no existe usuario, error contraseña, etc..
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Error de Singin, acceso a base de datos");
            }
        
            return RedirectToAction("Index", "Home");
        }
    }
}
