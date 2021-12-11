using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace WebAddressbookTests
{
    public class RemovingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestRemovingContactToGroup()
        {
            //new
            app.Navigator.GoToGroupsPage();
            if (app.Groups.GetGroupCount() == 0)
           {
               GroupData groups = new GroupData("aaa");
               groups.Header = "ddd";
               groups.Footer = "fff";
               app.Groups.Create(groups);
           }
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            //new
            if (oldList.Count==0) 
            {
                app.Navigator.GoToHomePage();
                if (app.Contacts.NotContact())
                {
                    app.Contacts.Create(1);
                }
                ContactData contacts = ContactData.GetContactsAll().Except(oldList).First();

                app.Contacts.AddContactToGroup(contacts, group);
                
            }

            //new
            ContactData contact = ContactData.GetContactsGroup(group.Id).First();
            app.Contacts.RemoveContactToGroup(contact,group);

            // actions

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
