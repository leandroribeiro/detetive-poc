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
    public class SuspeitoRepositoryFixture
    {
        private DetetiveContext _context;
        private ISuspeitoRepository _repository;

        [SetUp]
        public void Initializer()
        {
            _context = new DetetiveContext();
            _repository = new SuspeitoRepository(_context);
        }

        [Test]
        public void Deve_Obter_Um_Suspeito()
        {
            //Arrange
            int ID = 1;

            //Act
            Suspeito resultado = _repository.Obter(ID);

            //Assert
            Assert.IsNotNull(resultado);
        }

        [Test]
        public void Deve_Obter_Todos_Os_Suspeitos()
        {
            //Arrange

            //Act
            var resultado = _repository.Obter();

            //Assert
            Assert.IsNotNull(resultado);
            CollectionAssert.AllItemsAreNotNull(resultado);
            Assert.IsTrue(resultado.Any());
            Assert.IsTrue(resultado.Count() == 11);
        }
    }
}
