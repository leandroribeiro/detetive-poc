using System.Configuration;
using System.Linq;
using Detetive.Infrastructure;
using Detetive.WebAPI.Controllers;
using Xunit;

namespace Detetive.WebAPI.Tests
{
    public class ArmaControllerTest
    {
        [Fact]
        public void Arma_Controller_Get()
        {
            // Arrange
            var context = new DetetiveContext(ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            var uow = new UnitOfWork(context);
            var controller = new ArmaController(uow);

            // Act
            var result = controller.Get();

            // Assert
            Assert.True(result != null);
            Assert.Equal(10, result.Count());
            Assert.Equal("Fusioncutter", result.ElementAt(0).Nome);
            Assert.Equal("Wrist Rockets", result.ElementAt(1).Nome);
        }
    }
}
