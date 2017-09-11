using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionmateriales.Controllers;

namespace gestionmateriales.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Home_RetornaVistaIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
