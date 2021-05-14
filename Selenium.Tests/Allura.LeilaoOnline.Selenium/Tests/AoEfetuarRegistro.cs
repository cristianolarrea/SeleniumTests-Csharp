using Allura.LeilaoOnline.Selenium.Fixtures;
using Allura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace Allura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }


        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento() {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheForm(
                nome: "Fulano de Tal",
                email: "cristiano.leal@ntconsult.com",
                senha: "123",
                confirmSenha: "123");

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "testes@gmail.com", "123", "123")]
        [InlineData("Fulano válido", "testes", "123", "123")]
        [InlineData("Fulano válido", "testes@gmail.com", "123", "345")]
        [InlineData("Fulano válido", "testes@gmail.com", "123", "")]
        public void DadoInfoInValidasDevePermanecerNaPaginaInicial(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheForm(
                nome: nome, 
                email: email, 
                senha: senha, 
                confirmSenha: confirmSenha);

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact] 
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.SubmeteFormulario();

            Assert.Equal("The Nome field is required.", registroPO.NameMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheForm(
                nome: "Fulano",
                email: "cristiano.leal",
                senha: "123",
                confirmSenha: "123");
          
            registroPO.SubmeteFormulario();

            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagemDeErro()
        {
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            var spans = registroPO.FormRegistro.FindElements(By.TagName("spam"));
            foreach(var span in spans)
            {
                Assert.False(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
