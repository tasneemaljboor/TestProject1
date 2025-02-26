using HerfaTest_Batch_6.Helpers;
using HerfaTest_Batch_6.POM;
using OpenQA.Selenium;
using System;

namespace HerfaTest_Batch_6.POM
{
    public class Payment_POM
    {
        public IWebDriver _webDriver;

        public Payment_POM(IWebDriver driver)
        {
            _webDriver = driver;
        }

        By cardholdersName = By.XPath("//input[@id='CardholdersName']");
        By cardNumber = By.XPath("//input[@id='CardNumber']");
        By expiryDate = By.XPath("//input[@id='ExpiryDate']");
        By cvv = By.XPath("//input[@id='CVV']");
        By payButton = By.XPath("//button[contains(text(), 'Pay')]");

        public void EnterCardholdersName(string value)
        {
            IWebElement element = _webDriver.FindElement(cardholdersName);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterCardNumber(string value)
        {
            IWebElement element = _webDriver.FindElement(cardNumber);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterExpiryDate(string value)
        {
            IWebElement element = _webDriver.FindElement(expiryDate);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterCVV(string value)
        {
            IWebElement element = _webDriver.FindElement(cvv);
            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void ClickPayButton()
        {
            IWebElement element = _webDriver.FindElement(payButton);
            CommonMethods.Highlightelement(element);
            element.Click();
        }
    }
}
