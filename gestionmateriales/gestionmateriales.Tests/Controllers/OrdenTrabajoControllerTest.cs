using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionmateriales.Controllers;
using System.Web.Mvc;
using gestionmateriales.Models.GestionMateriales;

namespace gestionmateriales.Tests.Controllers
{
    [TestClass]
    public class OrdenTrabajoControllerTest
    {
        OrdenTrabajoController controller;
        public OrdenTrabajoControllerTest()
        {
            controller = new OrdenTrabajoController();
        }
        [TestMethod]
        public void OrdenTrabajo_RetornaVistaBuscarOT()
        {
            ViewResult result = controller.Buscar("", "", "") as ViewResult;
            Assert.IsNotNull("Buscar", result.ViewName);
        }
        [TestMethod]
        public void OrdenTrabajo_RetornaVistaAltaOT()
        {
            ViewResult result = controller.Alta() as ViewResult;
            Assert.IsNotNull("Alta", result.ViewName);
        }
        [TestMethod]
        public void OrdenTrabajo_RetornaVistaIndex()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull("Index", result.ViewName);
        }
    }
}
