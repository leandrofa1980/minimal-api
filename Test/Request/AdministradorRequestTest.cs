using System.Text;
using System.Text.Json;
using minimal_api.Dominio.ModelViews;
using Test.Helpers;

namespace Test.Request;

[TestClass]
public class AdministradorRequestTest
{
  [ClassInitialize]
  public static void ClassInit(TestContext testContext)
  {
    Helpers.Setup.ClassInit(testContext);
  }

  [ClassCleanup]
  public static void ClassCleanup()
  {
    Helpers.Setup.ClassCleanup();
  }

  [TestMethod]
  public async Task TestarGetSetPropriedades()
  {
    // Arrange
    var loginDTO = new LoginDTO
    {
      Email = "adm@teste.com",
      Senha = "123456"
    };
    var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");

    // Act
    var response = await Setup.client.PostAsync("/administradores/login", content);

    // Assert
    Assert.AreEqual(200, (int)response.StatusCode);
    var result = await response.Content.ReadAsStringAsync();
    var admLogado = JsonSerializer.Deserialize<AdministradorLogado>(result, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    });

    Assert.IsNotNull(admLogado?.Email ?? "");
    Assert.IsNotNull(admLogado?.Perfil ?? "");
    Assert.IsNotNull(admLogado?.Token ?? "");

    Console.WriteLine(admLogado?.Token);
  }
}
