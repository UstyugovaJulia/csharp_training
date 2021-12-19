using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NewLoginHelper
    {
        private  IWebDriver driver;
        private ApplicationManager applicationManager;

        public NewLoginHelper(IWebDriver driver, ApplicationManager applicationManager) {
            this.driver = driver;
            this.applicationManager = applicationManager;
        }

       /* public NewLoginHelper(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }*/

        public  void LoginIn(AccountData account)
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }
    }
}
