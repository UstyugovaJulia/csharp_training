﻿using System;
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
            Login(new AccountData("administrator", "root"));
            GoToProject1();
            SubmitProjectDelete();
        }

      

     

        

      
    }
}
