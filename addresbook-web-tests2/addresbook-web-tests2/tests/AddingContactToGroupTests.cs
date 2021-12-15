using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace WebAddressbookTests
{
   public  class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {//new
            app.Navigator.GoToGroupsPage();
            if (app.Groups.GetGroupCount() == 0)
          {
              GroupData groups = new GroupData("одна группа");
              groups.Header = "группа";
              groups.Footer = "группа одна";
              app.Groups.Create(groups);
          }

            GroupData group = GroupData.GetAll()[0];
          /*  for (int i; i > group.; i++)
            { 
            
            }*/
            List<ContactData> oldList = group.GetContacts();
            //new
            app.Navigator.GoToCreationContactPage();
            ContactData contact = ContactData.GetContactsAll().Except(oldList).FirstOrDefault();
           
            if (contact==null)
            {
                contact = new ContactData("Семенов");
                contact.Lastname = null;
                contact.Middlename = null;
                contact.Nickname = null;
                //app.Contacts.Create(1);
                app.Contacts.Create(contact);


            }
            contact= ContactData.GetContactsAll().Except(oldList).First();


            app.Contacts.AddContactToGroup(contact, group);
            //actions
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

      /*  [Test]
        public void TestAddingContactToGroupNew()
        {//new
            app.Navigator.GoToGroupsPage();
            if (app.Groups.GetGroupCount() == 0)
            {
                GroupData groups = new GroupData("одна группа");
                groups.Header = "группа";
                groups.Footer = "группа одна";
                app.Groups.Create(groups);
            }
           
            var  groupList = GroupData.GetAll();
            app.Navigator.GoToCreationContactPage();
            ContactData contact=null;
            List<ContactData> oldList=null;
            GroupData group=null;
            for (int i = 0; i < groupList.Count; i++)
            {
                group = groupList[i];
                oldList = groupList[i].GetContacts();
                //new
              
                contact = ContactData.GetContactsAll().Except(oldList).FirstOrDefault();
                if (contact!=null)
                { break; }


            }

            if (contact == null)
            {
                contact = new ContactData("Семенов");
                contact.Lastname = null;
                contact.Middlename = null;
                contact.Nickname = null;
                //app.Contacts.Create(1);
                app.Contacts.Create(contact);


            }
            //   ContactData contact;
            contact = ContactData.GetContactsAll().Except(oldList).First();


            app.Contacts.AddContactToGroup(contact, group);
            //actions
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }*/
    }

}
