using System.IO;
using Application.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.WebApi;

namespace Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código 
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validación";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametros_RetornarMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código 
            var userName = "AlexRam";
            var password = "123";
            var expected = "Autenticación exitosa!";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetronarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            //Arrange: Donde se inicializan los objetos necesarios para la ejecución del código 
            var userName = "AlexRam";
            var password = "123HRSRTYY";
            var expected = "Usuario no existe";

            //Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }
    }
}
