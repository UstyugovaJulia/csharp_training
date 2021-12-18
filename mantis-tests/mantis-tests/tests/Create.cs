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
            /*OpenHomePage();
            // loginHelper.Login(new AccountData("administrator", "root"));
            LoginIn(new AccountData("administrator", "root"));
            // AccountData account = new AccountData("administrator", "root");
            //   app.Auth.Login(account);
            */

            OpenHomePage();
            AccountData account = new AccountData("administrator", "root");
               app.Auth.Login(account);
          //  OpenHomePage();

            GoToProject();
            InitNewProjectCreation();
            ProjectData project = new ProjectData("test4");
            project.ProjectDescription = "test5";
            FillProjectForm(project);
            SubmitProjectCreation();
            Exit();
        }
 
    }
}
