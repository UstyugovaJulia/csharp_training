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
    public class Create:TestBase
    {
        
        [Test]
        public void CreateTest()
        {
            OpenHomePage();
            Login(new AccountData("administrator", "root"));
           // AccountData account = new AccountData("administrator", "root");
         //   app.Auth.Login(account);
          
            GoToProject();
            InitNewProjectCreation();
            ProjectData project = new ProjectData("test");
            project.ProjectDescription = "test2";
            FillProjectForm(project);
            SubmitProjectCreation();
            Exit();
        }
 
    }
}
