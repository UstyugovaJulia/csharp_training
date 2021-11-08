using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class ContactHelper:HelperBase
    {
      

        public ContactHelper(ApplicationManager manager):base(manager)
        {

          
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            GoToContactPage();
            ContactRemoval(v);
            ReturnToContactPage();
            return this;

        }

        

        public ContactHelper Edit(int v)
        {
            manager.Navigator.GoToHomePage();
            
            GoToContactPage();
            SelectedContact(v);
            ReturnToContactPage();
            return this;

        }

        public ContactHelper Create(int v)
        {
            manager.Navigator.GoToCreationContactPage();
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
            manager.Contacts
                .FillContactFormFIONickName(contact)
                .FillContactFormCompanyData(contact)
                .FillContactFormSecondary()
                .SubmitContactCreation()
                .GoToContactPage();
            return this;

        }


        public ContactHelper FillContactFormFIONickName(ContactData contact)
        {

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Birthday);
            driver.FindElement(By.XPath("//div[@id='content']/form/select/option[31]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Birthmonth);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[9]")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Birthyear);
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Anniverday);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[19]")).Click();
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Annivermonth);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[12]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Anniveryear);
            return this;
        }

        
       

        public ContactHelper FillContactFormCompanyData(ContactData contact)
        {
           
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.MobileNumber);
            Type(By.Name("mobile"), contact.MobileNumber);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("homepage"), contact.Homepage);
           
            return this;
        }


        public ContactHelper ReturnToAddressBook()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper FillContactFormSecondary()
        {
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("address2")).Click();
            return this;
        }

        public ContactHelper ContactRemoval(int v)
        {
            var EditIcon=driver.FindElements(By.XPath("//img[@alt='Edit']"));
            if (EditIcon == null || EditIcon.Count == 0)
            {
               
                Create(v);

            }
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            return this;
        }

        public ContactHelper GoToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }


        public ContactHelper SelectedContact(int v)
        {

              var EditIcon = driver.FindElements(By.XPath("//img[@alt='Edit']"));
              if (EditIcon == null || EditIcon.Count == 0)
              {
                  Create(v);
                 
              }
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
           
            return this;
        }

        public ContactHelper GoToEditPage(ContactData contact)
        {
          
            
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Birthday);
            driver.FindElement(By.XPath("//div[@id='content']/form/select/option[31]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Birthmonth);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[9]")).Click();
            Type(By.Name("byear"), contact.Birthyear);
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Anniverday);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[19]")).Click();
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Annivermonth);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[12]")).Click();
            Type(By.Name("ayear"), contact.Anniveryear);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.MobileNumber);
            Type(By.Name("mobile"), contact.MobileNumber);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }

        public List<ContactData> GetContactsList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr.entry"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }
    }
}
