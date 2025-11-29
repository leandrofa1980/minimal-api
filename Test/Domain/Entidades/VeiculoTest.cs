using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
[TestClass]
public class VeiculoTest
{
// Atividade de testar Veiculo
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.id = 1;
        veiculo.Nome = "TesteVeiculo";
        veiculo.Marca = "Testando";
        veiculo.Ano = 2023;

        // Assert
        Assert.AreEqual(1, veiculo.id);
        Assert.AreEqual("TesteVeiculo", veiculo.Nome);
        Assert.AreEqual("Testando", veiculo.Marca);
        Assert.AreEqual(2023, veiculo.Ano);

    }
}
}