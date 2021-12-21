using System;
using System.Collections.Generic;
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

            app.NewLogin.LoginIn(new AccountData("administrator", "root"));
            List<ProjectData> oldProjects = projectHelper.GetProjectAll();

            app.Projects.Create();
          //  List<ProjectData> oldProjects = projectHelper.GetProjectAll();

            /* newNavigator.OpenHomePage();
             newLoginHelper.LoginIn(new AccountData("administrator", "root"));
             newNavigator.OpenHomePage();
             newNavigator.GoToProject();
             projectHelper.InitNewProjectCreation();
             ProjectData project = new ProjectData("test");
             project.ProjectDescription = "test2";
             projectHelper.FillProjectForm(project);
             projectHelper.SubmitProjectCreation();
             projectHelper.Exit();*/
            List<ProjectData> newProjects = projectHelper.GetProjectAll();
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);


        }

    }
}
