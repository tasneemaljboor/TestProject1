﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest_Batch_6.Helpers
{
    public class ManageDriver
    {
        public static IWebDriver driver = new ChromeDriver();

        public static void MaximizeDriver()
        {
            driver.Manage().Window.Maximize();
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }
    }
}
