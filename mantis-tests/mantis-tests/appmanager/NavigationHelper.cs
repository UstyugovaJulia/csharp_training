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
   public class NavigationHelper:HelperBase
    {
       
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL):base(manager)
        {

         
            this.baseURL = baseURL;
        }

        /*    public void GoToHomePage()
            {
                // if (driver.Url == baseURL + "/addressbook/")
                if (driver.Url == baseURL + "/account_page.php")
                {
                    return;
                }
                //  driver.Navigate().GoToUrl(baseURL + "/addressbook/");
                driver.Navigate().GoToUrl(baseURL + "/account_page.php");
            }*/

        /*   public void GoToGroupsPage()
           {
               if (driver.Url == baseURL + "/addressbook/group.php"
                   && IsElementPresent(By.Name("new")))
               {
                   return;
               }
               driver.FindElement(By.LinkText("groups")).Click();
           }

           public void GoToCreationContactPage()
           {
                if (driver.Url == baseURL + "addressbook/edit.php")

               {
                   return;
               }
               driver.FindElement(By.LinkText("add new")).Click();
           }*/

        public void OpenHomePage()
        {
            // driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }
        public void GoToProject()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        public void GoToProject1()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
