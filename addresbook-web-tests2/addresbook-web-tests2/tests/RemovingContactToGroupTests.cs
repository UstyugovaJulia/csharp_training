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
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
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
