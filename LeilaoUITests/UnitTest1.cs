using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace LeilaoUITests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arange
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                ); ;

            //Act
            driver.Navigate().GoToUrl("https://www.caelum.com.br");

            //Assert
            Assert.Contains("Caelum", driver.Title);
        }
    }
}
