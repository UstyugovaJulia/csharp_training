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
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Remove(1);


                     
            List<ContactData> newContacts =  app.Contacts.GetContactsList();
            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

        }

       
    }
}
