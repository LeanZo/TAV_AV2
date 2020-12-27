using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TAV_AV2;
using System.Linq;

namespace TAV_AV2_TESTS
{
    [TestClass]
    public class PrincipalTest
    {
        [TestMethod]
        public void ReservarCarroLivreTeste()
        {
            // Arrange
            Repositorio.CarregarRepositorio();
            var carro = Principal.ListarCarros(null, null, CarroStatus.Livre).FirstOrDefault();
            var esperado = true;

            // Act
            var resultado = Principal.ReservarCarro(carro, false, TipoLocacao.Internet, new DateTime(2020, 12, 1), new DateTime(2020, 12, 7), PeriodoLocacao.SeteDias);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ReservarCarroNaoLivreTeste()
        {
            // Arrange
            Repositorio.CarregarRepositorio();
            var carro = Principal.ListarCarros().Where(car => car.CarroStatus != CarroStatus.Livre).FirstOrDefault();
            var esperado = false;

            // Act
            var resultado = Principal.ReservarCarro(carro, false, TipoLocacao.Internet, new DateTime(2020, 12, 1), new DateTime(2020, 12, 7), PeriodoLocacao.SeteDias);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void LocalizarCarroTeste()
        {
            // Arrange
            Repositorio.CarregarRepositorio();
            var carro = Principal.LocalizarCarro("MNB-4725");
            var esperado = 8;

            // Act
            var resultado = carro.Id;

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void ListarCarrosTeste()
        {
            // Arrange
            Repositorio.CarregarRepositorio();
            var carros = Principal.ListarCarros("Rio de Janeiro");
            var esperado = 3;

            // Act
            var resultado = carros.Count;

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void LocalizarCarroMaisProximoTeste()
        {
            // Arrange
            Repositorio.CarregarRepositorio();
            var loja = Repositorio.Lojas.Where(loj => loj.Id == 4).FirstOrDefault();
            var carro = Principal.LocalizarCarroMaisProximo(loja);
            var esperado = 4;

            // Act
            var resultado = carro.Id;

            // Assert
            Assert.AreEqual(esperado, resultado);
        }
    }
}
