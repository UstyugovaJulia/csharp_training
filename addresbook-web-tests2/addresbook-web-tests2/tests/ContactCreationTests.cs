using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
            {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)

            { 
            contacts.Add(new ContactData(GeneratrRandomString(30))
                    {
                    Firstname= GeneratrRandomString(20),
                    Lastname = GeneratrRandomString(20)

            });
            }
            return contacts;

}
        public static IEnumerable<ContactData> ContactDataFromCsvFile() 
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string s in lines)
            {
                string[]parts=s.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    Firstname=parts[1],
                    Lastname=parts[2]
                });
            }
                return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromCsvFile")]
        public void ContactCreationTest(ContactData contact)
        {
           

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            //app.Contacts.Create(1);

            app.Navigator.GoToCreationContactPage();
           /* ContactData contact = new ContactData("Иванов");
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
            contact.Homepage = "34";*/ 
            app.Contacts
                .FillContactFormFIONickName(contact)
                .FillContactFormCompanyData(contact)
                .FillContactFormSecondary()
                .SubmitContactCreation()
                .ReturnToAddressBook();
         //   Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);




        }





    }
}
