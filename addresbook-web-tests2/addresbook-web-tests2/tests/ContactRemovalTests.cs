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
    public class ContactRemovalTests : ContactTestBase
    {
      
        [Test]
        public void ContactRemovalTest()
        {

            if (app.Contacts.NotContact())
            {
                app.Contacts.Create(1);
            }
           
            List<ContactData> oldContacts = ContactData.GetContactsAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count-1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetContactsAll();

           
            foreach (ContactData contact in newContacts)
            {
             
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }


        }

       
    }
}
