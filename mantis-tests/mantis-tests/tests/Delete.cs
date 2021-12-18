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
    public class Delete:TestBase
    {
        

        [Test]
        public void DeleteTest()
        {
            OpenHomePage();
            // loginHelper.Login(new AccountData("administrator", "root"));
            // AccountData account = new AccountData("administrator", "root");
            // app.Auth.Login(account);
            /* LoginIn(new AccountData("administrator", "root"));*/
            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);
          //  OpenHomePage();

            GoToProject1();
            SubmitProjectDelete();
        }

      

     

        

      
    }
}
