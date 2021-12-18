using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace mantis_tests
{
   public class ProjectHelper:HelperBase
    {
      

        public ProjectHelper(ApplicationManager manager):base(manager)
        {

          
        }


        /*   public ProjectHelper Remove(int v)
            {
                manager.Navigator.GoToHomePage();
                GoToContactPage();
                ContactRemoval(v);
                ReturnToContactPage();
                return this;

            }

            public void RemoveContactToGroup(ContactData contact, GroupData group)
            {
                manager.Navigator.GoToHomePage();

                ClearGroupFilterAll();

                SelectedInContact(contact.Id);
                SelectGroupFilter(group.Name);
                SelectedInContact(contact.Id);
                DeleteContact();

                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                 .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            }

            public ContactHelper DeleteContact()
            {
                driver.FindElement(By.Name("remove")).Click();
                contactCache = null;
                return this;
            }

            public void SelectGroupFilter(string name)
            {
                new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
            }

            public ContactHelper Edit(int v)
            {
                manager.Navigator.GoToHomePage();

                GoToContactPage();
                SelectedContact(v);
                ReturnToContactPage();
                return this;

            }

            public ContactHelper Edit(ContactData contact, ContactData newData)
            {
                manager.Navigator.GoToHomePage();

                GoToContactPage();
                SelectedContact(contact.Id);
                ReturnToContactPage();
                return this;
            }

            public ContactHelper Remove(ContactData contact)
            {
                manager.Navigator.GoToHomePage();
                GoToContactPage();
                ContactRemoval(contact.Id);
                ReturnToContactPage();
                return this;
            }*/

        /*  public ProjectHelper Create(int v)
          {
              manager.Navigator.GoToCreationContactPage();
              ContactData contact = new ContactData("Иванов","Петр");*/
        // contact.Lastname = "Петр";
        /* contact.Middlename = "Иванович";
         contact.Nickname = "Ivanov";
         contact.Birthday = "14";
         contact.Birthmonth = "May";
         contact.Birthyear = "1980";
         contact.Anniverday = "14";
         contact.Annivermonth = "May";
         contact.Anniveryear = "1980";
         contact.Title = "TitleTest";
         contact.Address = "г. Омск";
         contact.Home = "13";
         contact.MobileNumber = "79131231211";
         contact.WorkNumber = "79131231212";
         contact.Email = "12@ya.ru";
         contact.Email2 = "13@ya.ru";
         contact.Homepage = "34";*/
        /*  manager.Contacts
              .FillContactFormFIONickName(contact)
              .FillContactFormCompanyData(contact)
              .FillContactFormSecondary()
              .SubmitContactCreation()
              .GoToContactPage();
          return this;

      }*/


        public void Exit()
        {
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/span")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void FillProjectForm()
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys("test");
            driver.FindElement(By.Id("project-description")).Click();
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys("test2");
        }

        public void InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("project-name")).Click();
        }

        public void GoToProject()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[6]/a/i")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        public void Login()
        {
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
        }


    }
}
