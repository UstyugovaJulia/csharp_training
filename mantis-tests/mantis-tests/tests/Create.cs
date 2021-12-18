using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    [TestFixture]
    public class Create
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
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
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        } 

        [Test]
        public void CreateTest()
        {
            OpenHomePage();
            Login(new AccountData("administrator", "root"));
            GoToProject();
            InitNewProjectCreation();
            ProjectData project = new ProjectData("test");
            project.ProjectDescription = "test2";
            FillProjectForm(project);
            SubmitProjectCreation();
            Exit();
        }

        public void Exit()
        {
            driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/span")).Click();
            driver.FindElement(By.LinkText("Выход")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
           // Type(By.Name("project-name"), project.ProjectName);
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.ProjectName);
            driver.FindElement(By.Id("project-description")).Click();
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.ProjectDescription);
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

        public void Login(AccountData account)
        {
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
        }
        /*  private bool IsElementPresent(By by)
 {
     try
     {
         driver.FindElement(by);
         return true;
     }
     catch (NoSuchElementException)
     {
         return false;
     }
 }

 private bool IsAlertPresent()
 {
     try
     {
         driver.SwitchTo().Alert();
         return true;
     }
     catch (NoAlertPresentException)
     {
         return false;
     }
 }

 private string CloseAlertAndGetItsText()
 {
     try
     {
         IAlert alert = driver.SwitchTo().Alert();
         string alertText = alert.Text;
         if (acceptNextAlert)
         {
             alert.Accept();
         }
         else
         {
             alert.Dismiss();
         }
         return alertText;
     }
     finally
     {
         acceptNextAlert = true;
     }
 }*/
    }
}
