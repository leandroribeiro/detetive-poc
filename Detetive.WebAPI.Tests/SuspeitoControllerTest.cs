using System.Configuration;
using System.Linq;
using Detetive.Infrastructure;
using Detetive.WebAPI.Controllers;
using Xunit;

namespace Detetive.WebAPI.Tests
{
    public class SuspeitoControllerTest
    {
        [Fact]
        public void Suspeito_Controller_Get()
        {
            // Arrange
            var context = new DetetiveContext(ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            var uow = new UnitOfWork(context);
            var controller = new SuspeitoController(uow);

            // Act
            var result = controller.Get();

            // Assert
            Assert.True(result != null);
            Assert.Equal(11, result.Count());
            Assert.Equal("Darth Vader", result.ElementAt(0).Nome);
            Assert.Equal("Darth Maul", result.ElementAt(1).Nome);
        }
    }
}
