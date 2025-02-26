using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomation
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private void PerformLogin(string username, string password)
        {
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login_button")).Click();
        }

        [Test]
        [TestCase("validUser", "validPass", "Login successful")]
        [TestCase("", "validPass", "sajedbushehab@yahoo.com is required")]
        [TestCase("validUser", "", "123456 is required")]
        [TestCase("invalidUser", "invalidPass", "Invalid credentials")]
        public void TestUserLogin(string username, string password, string expectedMessage)
        {
            driver.Navigate().GoToUrl("https://localhost:44349/Auth/Login"); // Replace with actual login URL

            // Exclude header and footer
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('header').style.display='none';");
            js.ExecuteScript("document.getElementById('footer').style.display='none';");

            PerformLogin(username, password);

            string confirmationMessage = driver.FindElement(By.Id("confirmation_message")).Text;
            Assert.IsTrue(confirmationMessage.Contains(expectedMessage), "Login message mismatch.");
        }
    }
}

