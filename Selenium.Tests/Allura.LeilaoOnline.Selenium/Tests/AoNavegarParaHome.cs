using Allura.LeilaoOnline.Selenium.Fixtures;
using Allura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Allura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome

    {
        //Setup
        private IWebDriver driver;
        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
          
            driver.Navigate().GoToUrl("http://localhost:5000");

            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        { 

            driver.Navigate().GoToUrl("http://localhost:5000");

            Assert.Contains("Leilões", driver.Title);
        }
    }
}
