using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
   public  class TestBase
    {

        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
           
        }
        public static Random rnd = new Random();

        public static string GeneratrRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }


        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        protected NewLoginHelper newLoginHelper;
        protected NewNavigationHelper newNavigator;
        protected ProjectHelper projectHelper;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();

            newLoginHelper = new NewLoginHelper(driver);
            newNavigator = new NewNavigationHelper(driver);
            projectHelper = new ProjectHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
             
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
       
    }
}
