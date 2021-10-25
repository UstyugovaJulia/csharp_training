using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupEditTests : TestBase
    {
       
        [Test]
        public void GroupEditTest()
        {
            GroupData group = new GroupData("vvv");
            group.Header = "aaa";
            group.Footer = "ttt";

            app.Groups.Edit(group);
        }

         }
}
