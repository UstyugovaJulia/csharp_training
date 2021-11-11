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
    public class ContactEditTests : AuthTestBase
    {



      
        [Test]
        public void ContactEditTest()
        {
            if (app.Contacts.NotContact())
            {
                app.Contacts.Create(1);
            }


            app.Contacts.Edit(1);
           
            ContactData contact = new ContactData("Семенов");
            contact.Lastname = null;
            contact.Middlename = null;
            contact.Nickname = null;
            contact.Birthday = "14";
            contact.Birthmonth = "May";
            contact.Birthyear = "1980";
            contact.Anniverday = "14";
            contact.Annivermonth = "May";
            contact.Anniveryear = "1980";
            contact.Title = null;
            contact.Address = null;
            contact.Home = null;
            contact.MobileNumber = null;
            contact.WorkNumber = null;
            contact.Email = null;
            contact.Email2 = null;
            contact.Homepage = null;
            app.Contacts
                .GoToEditPage(contact)
                .ReturnToContactPage();

        }
       
    }
}
