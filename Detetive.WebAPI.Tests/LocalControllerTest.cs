using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Infrastructure;
using Detetive.WebAPI.Controllers;
using Xunit;

namespace Detetive.WebAPI.Tests
{
    public class LocalControllerTest
    {
        [Fact]
        public void Local_Controller_Get()
        {
            // Arrange
            var context = new DetetiveContext(ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            var uow = new UnitOfWork(context);
            var controller = new LocalController(uow);

            // Act
            var result = controller.Get();

            // Assert
            Assert.True(result != null);
            Assert.Equal(14, result.Count());
            Assert.Equal("Ahch-To", result.ElementAt(0).Nome);
            Assert.Equal("Alderaan", result.ElementAt(1).Nome);
        }
    }
}
