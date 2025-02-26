using HerfaTest_Batch_6.Data;
using HerfaTest_Batch_6.Helpers;
using HerfaTest_Batch_6.POM;
using OpenQA.Selenium;
using System;

namespace HerfaTest_Batch_6.TestMethods
{
    [TestClass]
    public class Payment_TestMethods
    {
        [TestMethod]
        public void TestPayment_ValidCardDetails()
        {
            ManageDriver.MaximizeDriver();
            CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
            Thread.Sleep(5000);

            Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
            payment_POM.EnterCardholdersName("Ahmadomari);
            payment_POM.EnterCardNumber("1234123412340000");
            payment_POM.EnterExpiryDate("01/10/2030");
            payment_POM.EnterCVV("357");
            payment_POM.ClickPayButton();

            string expectedURL = "https://localhost:44349/PaymentSuccess";
            string actualURL = ManageDriver.driver.Url;

            Assert.AreEqual(expectedURL, actualURL, "Payment did not process successfully");
            Console.WriteLine("Test Case Completed Successfully");
            ManageDriver.driver.Quit();
        }

        [TestMethod]
        public void TestPayment_InvalidCardNumber()
        {
            ManageDriver.MaximizeDriver();
            CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
            Thread.Sleep(5000);

            Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
            payment_POM.EnterCardholdersName("Raghad Albetar");
            payment_POM.EnterCardNumber("123412341234")
            payment_POM.EnterExpiryDate("20/4/2026");
            payment_POM.EnterCVV("789");
            payment_POM.ClickPayButton();

            string expectedURL = GlobalConstant.paymentLink;
            string actualURL = ManageDriver.driver.Url;

            Assert.AreEqual(actualURL, expectedURL, "Invalid card number should not process");
            Console.WriteLine("Test Case Completed Successfully");
            ManageDriver.driver.Quit();
        }

        [TestMethod]
        public void TestPayment_ExpiredCard()
        {
            ManageDriver.MaximizeDriver();
            CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
            Thread.Sleep(5000);

            Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
            payment_POM.EnterCardholdersName("SajedaIyad");
            payment_POM.EnterCardNumber("1212181812121818");
            payment_POM.EnterExpiryDate("20/2/2023");
            payment_POM.EnterCVV("111");
            payment_POM.ClickPayButton();

            string expectedURL = GlobalConstant.paymentLink;
            string actualURL = ManageDriver.driver.Url;

            Assert.AreEqual(actualURL, expectedURL, "Expired card should not process");
            Console.WriteLine("Test Case Completed Successfully");
            ManageDriver.driver.Quit();
        }
    }
}

