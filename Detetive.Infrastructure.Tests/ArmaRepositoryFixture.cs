using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Detetive.Infrastructure.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Detetive.Infrastructure.Tests
{
    [TestFixture]
    public class ArmaRepositoryFixture
    {
        private DetetiveContext _context;
        private IArmaRepository _repository;

        [SetUp]
        public void Initializer()
        {
            _context = new DetetiveContext(System.Configuration.ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            _repository = new ArmaRepository(_context);
        }

        [Test]
        public void Deve_Obter_Uma_Arma()
        {
            //Arrange
            int ID = 1;

            //Act
            Arma resultado = _repository.GetByID(ID);

            //Assert
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void Deve_Obter_Todas_As_Armas()
        {
            //Arrange

            //Act
            var resultado = _repository.Get();

            //Assert
            Assert.IsNotNull(resultado);
            CollectionAssert.AllItemsAreNotNull(resultado);
            Assert.IsTrue(resultado.Any());
            Assert.IsTrue(resultado.Count() == 10);
        }

        [Test]
        public void Deve_Obter_Armas_Aleatoriamente()
        {
            //Arrange
            Arma resultado1;
            Arma resultado2;
        

            //Act
            resultado1 = _repository.GetRandom();
            resultado2 = _repository.GetRandom();

            //Assert
            Assert.AreNotEqual(resultado1.GetHashCode(), resultado2.GetHashCode());
        }
    }
}
