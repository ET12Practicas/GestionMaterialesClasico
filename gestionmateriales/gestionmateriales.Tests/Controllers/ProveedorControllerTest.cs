using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionmateriales.Controllers;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Tests.Controllers
{
    [TestClass]
    public class ProveedorControllerTest
    {
        ProveedorController controller;

        public ProveedorControllerTest()
        {
            controller = new ProveedorController();
        }

        [TestMethod]
        public void Proveedor_RetornaVistaBuscarProveedor()
        {
            ViewResult result = controller.Buscar("", "", "") as ViewResult;
            Assert.IsNotNull("Buscar", result.ViewName);
        }

        [TestMethod]
        public void Proveedor_RetornaVistaAgregarProveedor()
        {
            ViewResult result = controller.Agregar() as ViewResult;
            Assert.IsNotNull("Agregar", result.ViewName);
        }

        [TestMethod]
        public void Proveedor_RetornaVistaEditarProveedor()
        {
            ViewResult result = controller.Editar(1) as ViewResult;
            Assert.IsNotNull("Editar", result.ViewName);
        }

        [TestMethod]
        public void Proveedor_RetornaVistaIndex()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull("Index", result.ViewName);
        }
    }
}
