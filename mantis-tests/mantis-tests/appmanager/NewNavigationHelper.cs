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
   public class NewNavigationHelper
    {
        public IWebDriver driver;
        public ApplicationManager applicationManager;

        public NewNavigationHelper(IWebDriver driver, ApplicationManager applicationManager)
        {
            this.driver = driver;
            this.applicationManager = applicationManager;
        }

       /* public NewNavigationHelper(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }*/

        public NewNavigationHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
        }

        public void GoToProject()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        public void GoToProject1()
        {
            // driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/manage_proj_page.php");
        
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
