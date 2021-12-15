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
            //old
            //  Assert.AreEqual(fromTable.Firstname, fromForm.AllContacts);
            string result="";
            if (!string.IsNullOrEmpty(fromForm.Firstname)) {
                result += fromForm.Firstname+" ";
                    }
            if (!string.IsNullOrEmpty(fromForm.Middlename))
            {
                result += fromForm.Middlename + " ";
                
            }
            if (!string.IsNullOrEmpty(fromForm.Lastname))
            {
                result += fromForm.Lastname;
            }
            result = result.TrimEnd('\r',' ' , '\n')+ "\r\n";
            if (!string.IsNullOrEmpty(fromForm.Nickname))
            {
                result += fromForm.Nickname + "\r\n";
            }
            if (!string.IsNullOrEmpty(fromForm.Title))
            {
                result += fromForm.Title + "\r\n";
            }
            if (!string.IsNullOrEmpty(fromForm.Company))
            {
                result += fromForm.Company + "\r\n";
            }

            if (!string.IsNullOrEmpty(fromForm.Address))
            {
                result += fromForm.Address + "\r\n";
            }
           result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";
            if (!string.IsNullOrEmpty(fromForm.Home))
            {
                result += "H: " + fromForm.Home + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";

            if (!string.IsNullOrEmpty(fromForm.MobileNumber))
            {
                result += "M: " + fromForm.MobileNumber + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";

            if (!string.IsNullOrEmpty(fromForm.WorkNumber))
            {
                result += "W: " + fromForm.WorkNumber + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";

            if (!string.IsNullOrEmpty(fromForm.Fax))
            {
                result += "F: " + fromForm.Fax + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";


            if (!string.IsNullOrEmpty(fromForm.Email))
            {
                result += fromForm.Email + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";
            if (!string.IsNullOrEmpty(fromForm.Email2))
            {
                result += fromForm.Email2 + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";
            if (!string.IsNullOrEmpty(fromForm.Email3))
            {
                result += fromForm.Email3 + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";

            if (!string.IsNullOrEmpty(fromForm.Homepage))
            {
                result += "Homepage:"+ "\r\n"+fromForm.Homepage + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";
            if (!string.IsNullOrEmpty(fromForm.Birthday))
            {
                result += "Birthday "  + fromForm.Birthday + ".";
            }

            if (!string.IsNullOrEmpty(fromForm.Birthmonth))
            {
                result += " "+ fromForm.Birthmonth ;
            }
            
            if (!string.IsNullOrEmpty(fromForm.Birthyear))
            {
                result += " " + fromForm.Birthyear+ " (36)";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";
            if (!string.IsNullOrEmpty(fromForm.Anniverday))
            {
                result += "Anniversary " + fromForm.Anniverday + ".";
            }
            if (!string.IsNullOrEmpty(fromForm.Annivermonth))
            {
                result += " " + fromForm.Annivermonth;
            }

            if (!string.IsNullOrEmpty(fromForm.Anniveryear))
            {
                result += " " + fromForm.Anniveryear + " (34)";
            }

            result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";


            if (!string.IsNullOrEmpty(fromForm.Address2))
            {
                result += fromForm.Address2 + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";

            if (!string.IsNullOrEmpty(fromForm.Phone2))
            {
                result += "P: "+fromForm.Phone2 + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n\r\n";

            
            if (!string.IsNullOrEmpty(fromForm.Notes))
            {
                result +=  fromForm.Notes + "\r\n";
            }
            result = result.TrimEnd('\r', ' ', '\n') + "\r\n";





            Assert.AreEqual(fromTable.Firstname, result.TrimEnd('\r', ' ', '\n'));


            /*   if (!string.IsNullOrEmpty(fromForm.Address))
               {
                   result += fromForm.Address + "\r\n";
               }*/
            /*upd 11/12
            Assert.AreEqual(fromTable.Firstname, fromForm.Firstname + " " + fromForm.Middlename + " " + fromForm.Lastname + "\r\n" + fromForm.Nickname
               + "\r\nTitleTest\r\n" + fromForm.Address + "\r\n\r\nH: " + fromForm.Home + "\r\nM: " + fromForm.MobileNumber + "\r\n\r\n" +
               fromForm.Email + "\r\n" + fromForm.Email2 + "\r\nHomepage:\r\n" + fromForm.Homepage + "\r\n\r\nBirthday " +
               fromForm.Birthday + ". " + fromForm.Birthmonth + " " + fromForm.Birthyear + " (41)\r\nAnniversary "
               + fromForm.Anniverday + ". " + fromForm.Annivermonth + " " + fromForm.Anniveryear + " (41)");*/
            // );<> ""
            /* Assert.AreEqual(fromTable., fromForm.Address);
             Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
             Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);*/

        }
    }
}
