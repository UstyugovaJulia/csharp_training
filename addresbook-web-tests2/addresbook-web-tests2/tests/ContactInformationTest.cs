using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]

   public  class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
           ContactData fromTable= app.Contacts.GetContactInformationFromTable(0);
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
        [Test]
        public void TestContactView()
        {
            ContactData fromTable = app.Contacts.GetContactInformationViewFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromViewEditForm(0);

            //verification
            // Assert.AreEqual(fromTable.Firstname, fromForm.Firstname);
            //   Assert.AreEqual(fromTable.Firstname+fromTable.Middlename+fromTable.Lastname+fromTable, fromForm);
            //  Assert.AreEqual(fromTable, fromForm);
            //более верно
            //   Assert.AreEqual(fromForm, fromTable);
            Assert.AreEqual(fromTable.Firstname, fromForm.Firstname + " " + fromForm.Middlename + " " + fromForm.Lastname + "\r\n" + fromForm.Nickname 
                + "\r\nTitleTest\r\n" + fromForm.Address + "\r\n\r\nH: "+ fromForm.Home+ "\r\nM: "+fromForm.MobileNumber+ "\r\n\r\n"+
                fromForm.Email+ "\r\n"+fromForm.Email2+ "\r\nHomepage:\r\n"+fromForm.Homepage+ "\r\n\r\nBirthday "+
                fromForm.Birthday+ ". "+ fromForm.Birthmonth+ " "+ fromForm.Birthyear + " (41)\r\nAnniversary "
                +fromForm.Anniverday + ". " + fromForm.Annivermonth + " " + fromForm.Anniveryear + " (41)");
            // );<> ""
            /* Assert.AreEqual(fromTable., fromForm.Address);
             Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
             Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);*/

        }
    }
}
