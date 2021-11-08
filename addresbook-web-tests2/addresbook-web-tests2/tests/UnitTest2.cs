using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace addresbook_web_tests2.tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            /* string[] s = new string[] { "I", "want", "to", "sleep" };
             for (int i=0;i<s.Length;i=i+1)
             {
                 System.Console.Out.Write(s[i]+"\n");

             }

            string[] s = new string[] { "I", "want", "to", "sleep" };
            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");

            }

            IWebDriver driver=null;
            int attempt = 0;

            while (driver.FindElements(By.Id("test")).Count == 0 && attempt<60)
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }*/

            IWebDriver driver = null;
            int attempt = 0;

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
