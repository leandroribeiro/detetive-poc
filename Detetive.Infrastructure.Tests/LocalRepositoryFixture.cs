using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Detetive.Infrastructure.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detetive.Infrastructure.Tests
{
    [TestFixture]
    public class LocalRepositoryFixture
    {
        private DetetiveContext _context;
        private ILocalRepository _repository;

        [SetUp]
        public void Initializer()
        {
            _context = new DetetiveContext(System.Configuration.ConfigurationManager.ConnectionStrings["DetetiveContext"].ConnectionString);
            _repository = new LocalRepository(_context);
        }

        [Test]
        public void Deve_Obter_Um_Local()
        {
            //Arrange
            int ID = 1;

            //Act
            Local resultado = _repository.GetByID(ID);

            //Assert
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void Deve_Obter_Todos_Os_Locais()
        {
            //Arrange

            //Act
            var resultado = _repository.Get();

            //Assert
            Assert.IsNotNull(resultado);
            CollectionAssert.AllItemsAreNotNull(resultado);
            Assert.IsTrue(resultado.Any());
            Assert.IsTrue(resultado.Count() == 14);
        }

        [Test]
        public void Deve_Obter_Locais_Aleatoriamente()
        {
            //Arrange
            Local resultado1;
            Local resultado2;


            //Act
            resultado1 = _repository.GetRandom();
            resultado2 = _repository.GetRandom();

            //Assert
            Assert.AreNotEqual(resultado1.GetHashCode(), resultado2.GetHashCode());
        }
    }
}
