using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

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

        public void RemoveContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();

            ClearGroupFilterAll();

            SelectedInContact(contact.Id);
            SelectGroupFilter(group.Name);
            SelectedInContact(contact.Id);
            DeleteContact();
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
             .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.Name("remove")).Click();
            contactCache = null;
            return this;
        }

        public void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public ContactHelper Edit(int v)
        {
            manager.Navigator.GoToHomePage();
            
            GoToContactPage();
            SelectedContact(v);
            ReturnToContactPage();
            return this;

        }

        public ContactHelper Edit(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();

            GoToContactPage();
            SelectedContact(contact.Id);
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            GoToContactPage();
            ContactRemoval(contact.Id);
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Create(int v)
        {
            manager.Navigator.GoToCreationContactPage();
            ContactData contact = new ContactData("Иванов","Петр");
           // contact.Lastname = "Петр";
           /* contact.Middlename = "Иванович";
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
            manager.Contacts
                .FillContactFormFIONickName(contact)
                .FillContactFormCompanyData(contact)
                .FillContactFormSecondary()
                .SubmitContactCreation()
                .GoToContactPage();
            return this;

        }

       

       

        public ContactHelper SelectedContact(string id)
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToCreationContactPage();
            manager.Contacts
               .FillContactFormFIONickName(contact)
               .FillContactFormCompanyData(contact)
               .FillContactFormSecondary()
               .SubmitContactCreation()
               .GoToContactPage();
            return this;
        }

        public ContactData GetContactInformationFromViewEditForm(int index)
        {
            manager.Navigator.GoToHomePage();

            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileNumber = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workNumber = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string birthmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string birthyear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string anniverday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string annivermonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string anniveryear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string company=driver.FindElement(By.Name("company")).GetAttribute("value");
            string title= driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");



            return new ContactData(firstname, lastname, middlename, nickname, address, home, mobileNumber, email, email2, email3, homepage, birthday, birthmonth, birthyear, anniverday, annivermonth, anniveryear)
            {
                /*Address = address,
                Home = home,
                MobileNumber = mobileNumber,
                WorkNumber = workNumber,
                Email = email,
                Email2 = email2*/
                Company = company,
                Title=title,
                WorkNumber=workNumber,
                Fax=fax,
                Address2=address2,
                Phone2=phone2,
                Notes=notes,
            };
        }

        public ContactHelper FillContactFormFIONickName(ContactData contact)
        {

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            /*driver.FindElement(By.Name("bday")).Click();
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
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Anniveryear);*/
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
            contactCache = null;
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
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ContactRemoval(String id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'and @id='" + id + "']")).Click();
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
           
            contactCache = null;
            return this;
        }

        public bool NotContact()
        {
            return !IsElementPresent(By.XPath("//img[@alt='Edit']"));
        }

        public bool NotContact(ContactData contact)
        {
            return NotContact()
                    && IsElementPresent(By.XPath($"//td[text()='{contact.Firstname}')]"));
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

              /*var EditIcon = driver.FindElements(By.XPath("//img[@alt='Edit']"));
              if (EditIcon == null || EditIcon.Count == 0)
              {
                  Create(v);
                 
              }*/
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
           
            return this;
        }


        public ContactHelper ViewContact(int v)
        {

            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();

            return this;
        }

        public ContactHelper GoToEditPage(ContactData contact)
        {
          
            
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            /*    driver.FindElement(By.Name("bday")).Click();
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
                Type(By.Name("email2"), contact.Email2);*/
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public string OtherN { get; private set; }

        public List<ContactData> GetContactsList()
        {
            if (contactCache == null) 
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var column = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(element.Text) { Lastname = column[1].Text, Firstname = column[2].Text });

                }

            }
          
            return new List<ContactData> (contactCache);
        }

        public int GetContactCount()
        {
          return  driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
                }


        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
           IList<IWebElement> cells= driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstname, lastname)
            {
                Address = address,
                
                AllEmails=allEmails,
                AllPhones = allPhones,
                
            };

        }

        public ContactData GetContactInformationViewFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            ViewContact(1);
            IList<IWebElement> otherAll = driver.FindElements(By.Id("content"));
            string otherN = otherAll[0].Text;
            return new ContactData(otherN);
          

        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();

            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileNumber = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workNumber = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstname, lastname, middlename)
            {
                Address = address,
                Home = home,
                MobileNumber = mobileNumber,
                WorkNumber = workNumber,
                Email = email,
                Email2 = email2,
                Email3 = email3,

            };
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public int GetNumberOfSearchResults() 
        {
            manager.Navigator.GoToHomePage();
           string text= driver.FindElement(By.TagName("label")).Text;
           Match m= new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilterNone();
            SelectedInContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectedInContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void ClearGroupFilterAll()
        {
             new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
            // new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");
        }

        public void ClearGroupFilterNone()
        {
           // new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
             new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");
        }
    }
}
