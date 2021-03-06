using System;
using System.Collections.Generic;
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
    public class ContactEditTests : ContactTestBase
    {



      
        [Test]
        public void ContactEditTest()
        {
            if (app.Contacts.NotContact())
            {
                app.Contacts.Create(1);
            }
            ContactData contact = new ContactData("Семенов");
            contact.Lastname = null;
            contact.Middlename = null;
            contact.Nickname = null;
            /*  contact.Birthday = "14";
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
              contact.Homepage = null;*/
            app.Contacts
                .GoToEditPage(contact)
                .ReturnToContactPage();

            
            List<ContactData> oldContacts = ContactData.GetContactsAll();
           
            ContactData oldData = oldContacts[0];
           
            app.Contacts.Edit(oldData, contact);
          

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetContactsAll();
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

           
        }

       

    }
}
