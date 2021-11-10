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
   public class GroupHelper:HelperBase
    {
       

        public GroupHelper(ApplicationManager manager):base (manager)
        {

        
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
               ReturnToGroupsPage();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

       
        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

       
        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
           // GroupNot(p);
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;

        }

       

        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)

        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
           // driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

     /*   public GroupHelper GroupNot(int index)
        {

            var EditIcon = driver.FindElements(By.XPath("//input[@name='selected[]'][" + (index + 1) + "]"));
            if (EditIcon != null)
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";

                manager.Groups.Create(group);
            }

            return this;
        }*/

        

        public GroupHelper SelectGroup(int index)
        {

           /* var EditIcon = driver.FindElements(By.XPath("//input[@name='selected[]'][" + (index+1) + "]"));

            if (EditIcon == null || EditIcon.Count == 0)
            {

                
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";


                manager.Groups.Create(group);

            }*/


            
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index+1) + "]")).Click();

            return this;
        }

       /* public GroupHelper Create(int v)
        {
            return this;
        }*/

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupChache = null;
            return this;
        }

        

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private List<GroupData> groupChache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupChache == null)
            {
                groupChache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupChache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupChache);

        }

        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }

    }
}
