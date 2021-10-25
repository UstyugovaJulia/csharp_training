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
    public class ContactEditTests : TestBase
    {



      
        [Test]
        public void ContactEditTest()
        {
           
            app.Contacts.Edit(1);
           
            ContactData contact = new ContactData("Петров");
            contact.Lastname = "Олег";
            contact.Middlename = "Олегович";
            contact.Nickname = "Ivanov";
            contact.Birthday = "14";
            contact.Birthmonth = "May";
            contact.Birthyear = "1980";
            contact.Anniverday = "14";
            contact.Annivermonth = "May";
            contact.Anniveryear = "1980";
            contact.Title = "Title";
            contact.Address = "г. Тюмень";
            contact.Home = "13";
            contact.MobileNumber = "79131231213";
            contact.WorkNumber = "79131231214";
            contact.Email = "16@ya.ru";
            contact.Email2 = "17@ya.ru";
            contact.Homepage = "4";
            app.Contacts
                .GoToEditPage(contact)
                .ReturnToContactPage();

        }
       
    }
}
