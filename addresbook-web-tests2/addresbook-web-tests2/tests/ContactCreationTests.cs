using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: AuthTestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
           

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            //app.Contacts.Create(1);

            app.Navigator.GoToCreationContactPage();
            ContactData contact = new ContactData("Иванов");
            contact.Lastname = "Петр";
            contact.Middlename = "Иванович";
            contact.Nickname = "Ivanov";
            contact.Birthday = "14";
            contact.Birthmonth = "May";
            contact.Birthyear = "1980";
            contact.Anniverday = "14";
            contact.Annivermonth = "May";
            contact.Anniveryear = "1980";
            contact.Title = "TitleTest";
            contact.Address = "г. Омск";
            contact.Home = "13";
            contact.MobileNumber = "79131231211";
            contact.WorkNumber = "79131231212";
            contact.Email = "12@ya.ru";
            contact.Email2 = "13@ya.ru";
            contact.Homepage = "34";
            app.Contacts
                .FillContactFormFIONickName(contact)
                .FillContactFormCompanyData(contact)
                .FillContactFormSecondary()
                .SubmitContactCreation()
                .ReturnToAddressBook();

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);




        }





    }
}
