using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionmateriales.Controllers;
using System.Web.Mvc;

namespace gestionmateriales.Tests.Controllers
{
    [TestClass]
    public class PersonalControllerTest
    {
        PersonalController controller;

        public PersonalControllerTest()
        {
            controller = new PersonalController();
        }

        [TestMethod]
        public void Personal_RetornaVistaIndex()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull("Index", result.ViewName);
        }

        [TestMethod]
        public void Personal_RetornaVistaAgregarPersonal()
        {
            ViewResult result = controller.Agregar() as ViewResult;
            Assert.IsNotNull("Agregar", result.ViewName);
        }

        [TestMethod]
        public void Personal_RetornaVistaBuscarPersonal()
        {
            ViewResult result = controller.Buscar("", "", "") as ViewResult;
            Assert.IsNotNull("Buscar", result.ViewName);
        }

        [TestMethod]
        public void Personal_RetornaVistaEditarPersonal()
        {
            ViewResult result = controller.Editar(1) as ViewResult;
            Assert.IsNotNull("Editar", result.ViewName);
        }
    }
}
