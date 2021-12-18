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
           newNavigator.OpenHomePage();
           newLoginHelper.LoginIn(new AccountData("administrator", "root"));
           
           newNavigator.GoToProject1();
           projectHelper.SubmitProjectDelete();
        }

      

     

        

      
    }
}
