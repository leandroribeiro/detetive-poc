using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Moq;
using Detetive.Domain.Services;

namespace Detetive.Domain.Tests
{
    [TestFixture]
    public class TestemunhaTestFixture
    {
        private ICasoRepository _casoRepo;
        private ISuspeitoRepository _suspeitoRepo;
        private ILocalRepository _localRepo;
        private IArmaRepository _armaRepo;
        private ICasoService _service;
        private Caso _caso;

        [SetUp]
        public void TestInitializer()
        {
            var mockCasoRepo = new Mock<ICasoRepository>();
            //mockCasoRepo.Setup(x=>x.Obter())
            _casoRepo = mockCasoRepo.Object;

            var mockSuspeitoRepo = new Mock<ISuspeitoRepository>();
            mockSuspeitoRepo.Setup(x => x.Obter(1)).Returns(new Suspeito("Darth Vader"));
            mockSuspeitoRepo.Setup(x => x.Obter(2)).Returns(new Suspeito("Darth Maul"));
            mockSuspeitoRepo.Setup(x => x.Obter(3)).Returns(new Suspeito("Darth Sidious"));
            mockSuspeitoRepo.Setup(x => x.Obter(4)).Returns(new Suspeito("Strorm Trooper"));
            mockSuspeitoRepo.Setup(x => x.Obter(5)).Returns(new Suspeito("Boba Fett"));
            mockSuspeitoRepo.Setup(x => x.Obter(6)).Returns(new Suspeito("GRAND MOFF TARKIN"));
            mockSuspeitoRepo.Setup(x => x.Obter(7)).Returns(new Suspeito("JABBA THE HUTT"));
            mockSuspeitoRepo.Setup(x => x.Obter(8)).Returns(new Suspeito("COUNT DOOKU"));
            mockSuspeitoRepo.Setup(x => x.Obter(9)).Returns(new Suspeito("GENERAL GRIEVOUS"));
            mockSuspeitoRepo.Setup(x => x.Obter(10)).Returns(new Suspeito("ASAJJ VENTRESS"));
            mockSuspeitoRepo.Setup(x => x.Obter(11)).Returns(new Suspeito("CAD BANE"));
            _suspeitoRepo = mockSuspeitoRepo.Object;

            var mockLocalRepo = new Mock<ILocalRepository>();
            //https://en.wikipedia.org/wiki/List_of_Star_Wars_planets_and_moons
            //mockLocalRepo.Setup(x => x.Obter(It.IsAny<Int32>())).Returns(new Local("Tatooine"));
            mockLocalRepo.Setup(x => x.Obter(1)).Returns(new Local("Ahch-To"));
            mockLocalRepo.Setup(x => x.Obter(2)).Returns(new Local("Alderaan"));
            mockLocalRepo.Setup(x => x.Obter(3)).Returns(new Local("Bespin"));
            mockLocalRepo.Setup(x => x.Obter(4)).Returns(new Local("Cato Neimoidia"));
            mockLocalRepo.Setup(x => x.Obter(5)).Returns(new Local("Christophsis"));
            mockLocalRepo.Setup(x => x.Obter(6)).Returns(new Local($"Coruscant"));
            mockLocalRepo.Setup(x => x.Obter(7)).Returns(new Local("Crait"));
            mockLocalRepo.Setup(x => x.Obter(8)).Returns(new Local("D'Qar"));
            mockLocalRepo.Setup(x => x.Obter(9)).Returns(new Local("Dagobah"));
            mockLocalRepo.Setup(x => x.Obter(10)).Returns(new Local("Eadu"));
            mockLocalRepo.Setup(x => x.Obter(11)).Returns(new Local("Endor"));
            mockLocalRepo.Setup(x => x.Obter(12)).Returns(new Local("Felucia"));
            mockLocalRepo.Setup(x => x.Obter(13)).Returns(new Local("Geonosis"));
            mockLocalRepo.Setup(x => x.Obter(14)).Returns(new Local("Hosnian Prime"));
            _localRepo = mockLocalRepo.Object;

            var mockArmaRepo = new Mock<IArmaRepository>();
            //http://www.gadgetreview.com/10-top-stars-wars-weapons
            //mockArmaRepo.Setup(x => x.Obter(It.IsAny<Int32>())).Returns(new Arma("Sabre de luz"));
            mockArmaRepo.Setup(x => x.Obter(1)).Returns(new Arma("Fusioncutter"));
            mockArmaRepo.Setup(x => x.Obter(2)).Returns(new Arma("Wrist Rockets"));
            mockArmaRepo.Setup(x => x.Obter(3)).Returns(new Arma("Flamethower "));
            mockArmaRepo.Setup(x => x.Obter(4)).Returns(new Arma("Missile Launchers"));
            mockArmaRepo.Setup(x => x.Obter(5)).Returns(new Arma("Ryyk Blades"));
            mockArmaRepo.Setup(x => x.Obter(6)).Returns(new Arma("Flechette Launcher"));
            mockArmaRepo.Setup(x => x.Obter(7)).Returns(new Arma("Force Pike"));
            mockArmaRepo.Setup(x => x.Obter(8)).Returns(new Arma("Bowcaster "));
            mockArmaRepo.Setup(x => x.Obter(9)).Returns(new Arma("Blaster"));
            mockArmaRepo.Setup(x => x.Obter(10)).Returns(new Arma("Lightsaber"));
            _armaRepo = mockArmaRepo.Object;

            _service = new CasoService(_casoRepo, _suspeitoRepo, _armaRepo, _localRepo);

            var suspeito = _suspeitoRepo.Obter(1);
            var local = _localRepo.Obter(1);
            var arma = _armaRepo.Obter(1);
            var testemunha = new Testemunha();

            _caso = new Caso(suspeito, local, arma, testemunha);
        }

        [Test]
        public void Dado_Uma_Teoria_Totalmente_Errada_Deve_Retornar_1_ou_2_ou_3()
        {
            //Arrange
            var suspeito = _suspeitoRepo.Obter(2);
            var local = _localRepo.Obter(2);
            var arma = _armaRepo.Obter(2);

            var teoria = new Teoria(suspeito, local, arma);

            //Act
            var resposta = _service.InterrogarTestemunha(_caso, teoria);


            //Assert
            Assert.That(resposta, Is.InRange(1, 3));
        }

        [Test]
        public void Dado_Uma_Teoria_Com_Supeito_Errado_deve_Retornar_1()
        {
            //Arrange
            var suspeito = _suspeitoRepo.Obter(2);
            var local = _localRepo.Obter(1);
            var arma = _armaRepo.Obter(1);

            var teoria = new Teoria(suspeito, local, arma);

            //Act
            var resposta = _service.InterrogarTestemunha(_caso, teoria);


            //Assert
            Assert.AreEqual(resposta, 1);
        }

        [Test]
        public void Dado_Uma_Teoria_Com_Local_Errado_deve_Retonar_2()
        {
            //Arrange
            var suspeito = _suspeitoRepo.Obter(1);
            var local = _localRepo.Obter(2);
            var arma = _armaRepo.Obter(1);

            var teoria = new Teoria(suspeito, local, arma);

            //Act
            var resposta = _service.InterrogarTestemunha(_caso, teoria);


            //Assert
            Assert.AreEqual(resposta, 2);
        }

        [Test]
        public void Dado_Uma_Teoria_Com_Arma_Errada_deve_Retonar_3()
        {
            //Arrange
            var suspeito = _suspeitoRepo.Obter(1);
            var local = _localRepo.Obter(1);
            var arma = _armaRepo.Obter(2);

            var teoria = new Teoria(suspeito, local, arma);

            //Act
            var resposta = _service.InterrogarTestemunha(_caso, teoria);


            //Assert
            Assert.AreEqual(resposta, 3);
        }

        [Test]
        public void Dado_Uma_Teoria_Correta_deve_Retonar_0()
        {
            //Arrange
            var suspeito = _suspeitoRepo.Obter(1);
            var local = _localRepo.Obter(1);
            var arma = _armaRepo.Obter(1);

            var teoria = new Teoria(suspeito, local, arma);

            //Act
            var resposta = _service.InterrogarTestemunha(_caso, teoria);


            //Assert
            Assert.AreEqual(resposta, 0);
        }
    }
}
