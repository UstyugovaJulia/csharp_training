using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace mantis_tests
{
    [TestFixture]
    public class Delete:TestBase
    {
        

        [Test]
        public void DeleteTest()
        {
            /*newNavigator.OpenHomePage();
             newLoginHelper.LoginIn(new AccountData("administrator", "root"));

             newNavigator.GoToProject1();
             projectHelper.SubmitProjectDelete();*/
            app.NewLogin.LoginIn(new AccountData("administrator", "root"));
            ProjectData projectData = new ProjectData();
            List<ProjectData> projects = app.Projects.GetProjectAll();
            
            


            if ( projects.Count==0)
                    {
                app.Projects.Create();
            }
           app.Projects.Remove();


            Assert.AreEqual(projects.Count, app.Projects.GetProjectCount());

              List<ProjectData> newProjects = app.Projects.GetProjectAll();
          projects.RemoveAt(0);
              projects.Sort();
              newProjects.Sort();


               foreach (ProjectData project in newProjects)
              {

                  Assert.AreNotEqual(project.ProjectName, projectData.ProjectName);
              }

        }





    }
}
