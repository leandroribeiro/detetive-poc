using System.Configuration;
using Detetive.Domain.Services;
using Detetive.Infrastructure;
using Detetive.WebAPI.Controllers;
using Detetive.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Detetive.WebAPI.Tests
{
    public class CasoControllerTest
    {
        [Fact]
        public void Caso_Controller_Novo()
        {
            // Arrange
            var context = new DetetiveContext(ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            var uow = new UnitOfWork(context);
            var service = new CasoService(uow);
            var controller = new CasoController(service);

            // Act
            var result = controller.Novo();

            // Assert
            Assert.True(result != null, "result != null");
            Assert.True(result is OkObjectResult, "result is OkObjectResult");

            var okResult = result as OkObjectResult;

            Assert.True(okResult.Value is CasoResponseModel, "okResult.Value is CasoResponseModel");

            var casoResponse = (CasoResponseModel) okResult.Value;

            Assert.True(casoResponse.Id > 0, "casoResponse.Id > 0");
            Assert.False(string.IsNullOrEmpty(casoResponse.DataAbertura), "string.IsNullOrEmpty(casoResponse.DataAbertura)");
        }

        [Fact]
        public void Caso_Controller_InterrogarTestemunha()
        {
            // Arrange
            var context = new DetetiveContext(ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            var uow = new UnitOfWork(context);
            var service = new CasoService(uow);
            var controller = new CasoController(service);

            var casoId = 1;
            var armaId = 1;
            var localId = 1;
            var suspeitoId = 1;

            // Act
            var result = controller.InterrogarTestemunha(casoId, armaId, localId, suspeitoId);

            // Assert
            Assert.True(result != null, "result != null");
            Assert.True(result is OkObjectResult, "result is OkObjectResult");

            var okResult = result as OkObjectResult;

            Assert.True(okResult.Value is int, "okResult.Value is int");

            var response = (int)okResult.Value;

            Assert.Equal(0, response);
        }
    }
}
