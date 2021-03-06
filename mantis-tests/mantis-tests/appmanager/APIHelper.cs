using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public string baseUrl;

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();

            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();

            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();

            project.name = projectData.ProjectName;
            project.description = projectData.ProjectDescription;

            client.mc_project_add(account.Name, account.Password, project);
        }

        public List<ProjectData> GetProjectAll(AccountData account)
        { 
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> projects1 = new List<ProjectData>();

             foreach (Mantis.ProjectData project in projects)

                        {

                            projects1.Add(new ProjectData(project.name));
            }


                return projects1;

        }

        public APIHelper(ApplicationManager manager) : base(manager) 
        {
           
        }

       
    }

}
