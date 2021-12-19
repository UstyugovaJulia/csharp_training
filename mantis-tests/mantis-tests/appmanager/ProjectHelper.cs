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
   public class ProjectHelper
        //:HelperBase
    {


        /*   public ProjectHelper(ApplicationManager manager):base(manager)
           {


           }*/

        public IWebDriver driver;
        public ApplicationManager applicationManager;

        public ProjectHelper(IWebDriver driver, ApplicationManager applicationManager)
        {
            this.driver = driver;
            this.applicationManager = applicationManager;
        }

        public void Remove()
        {
        // applicationManager.NewNavigation.OpenHomePage();
        // applicationManager.NewLogin.LoginIn(new AccountData("administrator", "root"));

            applicationManager.NewNavigation.GoToProject1();
            SubmitProjectDelete();
        }

        public void Create()
        {
            applicationManager.NewNavigation.OpenHomePage();
          //  applicationManager.NewLogin.LoginIn(new AccountData("administrator", "root"));
           // applicationManager.NewNavigation.OpenHomePage();
            applicationManager.NewNavigation.GoToProject();
            InitNewProjectCreation();
            ProjectData project = new ProjectData("test");
            project.ProjectDescription = "test2";
            FillProjectForm(project);
            SubmitProjectCreation();
          // Exit();
        }
        public ProjectHelper(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
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
        public void SubmitProjectDelete()
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public  List<ProjectData> GetProjectAll()
        {
           
          //  applicationManager.NewNavigation.OpenHomePage();
           // applicationManager.NewLogin.LoginIn(new AccountData("administrator", "root"));

            applicationManager.NewNavigation.GoToProject1();
            var elements = driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a"));
            // var element = elements[i];
            if (elements.Count ==0)
            { return new List<ProjectData>(); }
            var element = elements[0];
            ProjectData project = new ProjectData();
            project.ProjectName = element.FindElements(By.XPath("//tr/td"))[0].Text;
            project.Id= element.FindElements(By.XPath("//tr/td"))[0].Text;

            List<ProjectData> projects = new List<ProjectData> { project };

           /* for (int i; i < elements.Count; i++)
            { 
            
            }*/

            return projects;
        }
    }
}
