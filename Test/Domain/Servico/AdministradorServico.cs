using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos.AdministradorServico;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTest
{
  private DbContexto CriarContextoDeTeste()
  {
    var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
    // Configurar o ConfigurationBuilder
    var build = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
    var configuration = build.Build();

    return new DbContexto(configuration);
  }

  [TestMethod]
  public void TestandoBuscaPorId()
  {
    // Arrange
    var context = CriarContextoDeTeste();
    context.Database.ExecuteSqlRaw("TRUNCATE TABLE administradores");
    
    var adm = new Administrador();
    adm.Email = "teste@test.com";
    adm.Senha = "teste";
    adm.Perfil = "adm";


    var administradorServico = new AdministradorServico(context);

    // Act
    administradorServico.Incluir(adm);
    var admDoBanco = administradorServico.BuscaPorId(adm.Id);

    // Assert
    Assert.AreEqual(1,admDoBanco.Id);
    Assert.AreEqual("teste@test.com", adm.Email);
    Assert.AreEqual("teste", adm.Senha);
    Assert.AreEqual("adm", adm.Perfil);

  }
}
