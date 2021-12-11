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
              if (app.Groups.GetGroupCount() == 0)
          {
              GroupData groups = new GroupData("одна группа");
              groups.Header = "группа";
              groups.Footer = "группа одна";
              app.Groups.Create(groups);
          }
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            //new
            if (app.Contacts.NotContact())
            {
                app.Contacts.Create(1);
            }
            ContactData  contact= ContactData.GetContactsAll().Except(oldList).First();


            app.Contacts.AddContactToGroup(contact, group);
            //actions
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }

}
