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
    public class ContactRemovalTests : AuthTestBase
    {
      
        [Test]
        public void ContactRemovalTest()
        {

            if (app.Contacts.NotContact())
            {
                app.Contacts.Create(1);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(0);


                     
            List<ContactData> newContacts =  app.Contacts.GetContactsList();

            //oldContacts.RemoveAt(0);
            //Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
             //   Assert.AreNotEqual(contact.Firstname, toBeRemoved.Firstname);
             //   Assert.AreNotEqual(contact.Lastname, toBeRemoved.Lastname);
                Assert.AreNotEqual(contact, toBeRemoved);

            }


        }

       
    }
}
