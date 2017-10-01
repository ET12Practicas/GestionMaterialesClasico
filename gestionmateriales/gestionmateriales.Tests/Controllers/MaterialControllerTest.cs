using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionmateriales.Controllers;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Tests.Controllers
{
    [TestClass]
    public class MaterialControllerTest
    {
        MaterialController controller;

        public MaterialControllerTest()
        {
            controller = new MaterialController();
        }
        [TestMethod]
        public void Material_RetornaVistaIndex()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull("Index", result.ViewName);
        }

        [TestMethod]
        public void Material_RetornaVistaAltaMaterial()
        {
            ViewResult result = controller.Alta() as ViewResult;
            Assert.IsNotNull("Alta", result.ViewName);
        }

        [TestMethod]
        public void Material_RetornaVistaEditarMaterial()
        {
            ViewResult result = controller.Editar(1) as ViewResult;
            Assert.IsNotNull("Editar", result.ViewName);
        }

        [TestMethod]
        public void Material_RetornaVistaBuscarMaterial()
        {
            ViewResult result = controller.Buscar("", "", "") as ViewResult;
            Assert.IsNotNull("Buscar", result.ViewName);
        }
    }
}
