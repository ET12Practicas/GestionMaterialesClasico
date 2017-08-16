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
        pp67_usuariosEntities db = new pp67_usuariosEntities();
        //ot_usuariosEntities db = new ot_usuariosEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult SingIn(string unUsuario, string unaContrasenia, string unRol)
        {
            try
            {
                int rol = db.rol.First(y => y.Nombre.Equals(unRol)).idRol;

                bool res = db.usuario.Any(x => x.nombre.Equals(unUsuario) &&
                    x.contrasenia.Equals(unaContrasenia) &&
                    x.idRol == rol);

                if (!res)
                {
                    //TODO: Mostrar pantalla error, ver tipos de errores, no existe usuario, error contraseña
                    return RedirectToAction("Index", "Login");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        
            return RedirectToAction("Index", "Home");
        }
    }
}
