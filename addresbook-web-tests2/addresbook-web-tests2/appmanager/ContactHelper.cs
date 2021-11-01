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
            ContactRemoval();
            ReturnToContactPage();
            return this;

        }

        public ContactHelper Edit(int v)
        {
            manager.Navigator.GoToHomePage();
            
            GoToContactPage();
            SelectedContact();
            ReturnToContactPage();
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

        public ContactHelper ContactRemoval()
        {
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


        public ContactHelper SelectedContact()
        {
            driver.FindElement(By.Id("2")).Click();
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

       
    }
}
