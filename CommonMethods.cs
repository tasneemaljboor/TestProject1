﻿using Bytescout.Spreadsheet;
using HerfaTest_Batch_6.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest_Batch_6.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            ManageDriver.driver.Navigate().GoToUrl(url);
        }
        public static void Highlightelement(IWebElement element)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow !important')", element);
            Thread.Sleep(1000);
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
        }

        public static Worksheet ReadExcel(string sheetName)//Register
        {
            Spreadsheet Excel = new Spreadsheet();
            Excel.LoadFromFile(GlobalConstant.HerfaTestDataPath);
            Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);
            return worksheet;
        }

        public static string TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string path = "C:\\Users\\b.alhassoun.ext\\source\\repos\\HerfaTest-Batch 6\\HerfaTest-Batch 6\\Data\\Images";
            string imageName = Guid.NewGuid().ToString() + "_image.png"; // 2145625-2722-2872-2729-268682372139_image.png
            string fullPath = Path.Combine(path + $"\\{imageName}");// "C:\\Users\\b.alhassoun.ext\\source\\repos\\HerfaTest-Batch 6\\HerfaTest-Batch 6\\Data\\Images\\2145625-2722-2872-2729-268682372139_image.png
            screenshot.SaveAsFile(fullPath);
            return fullPath;
        }


        public static IWebElement WaitAndFindElement(By by)//By.XPath("//div/input[@id='Fname']");
        {
            var waiting = new DefaultWait<IWebDriver>(ManageDriver.driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            waiting.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element = waiting.Until(x => x.FindElement(by));
            return element;
        }
    }
}
