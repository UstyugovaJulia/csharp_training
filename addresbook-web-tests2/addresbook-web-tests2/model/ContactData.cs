using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string title = "";
        private string company= "";
        private string allPhones;
        private string allEmails;
        private string allContacts;
       // private string otherN;

        public ContactData() 
        { 
        }

        public ContactData(string firstname, string lastname,string middlename)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
        }


        public ContactData(string firstname, string lastname, string middlename, string nickname,string address, string home,string mobileNumber,
            string email, string email2, string email3, string homepage, string birthday, string birthmonth, string birthyear, string anniverday,string annivermonth, string anniveryear)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Nickname = nickname;
            Address = address;
            Home = home;
            MobileNumber = mobileNumber;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            Birthday = birthday;
            Birthmonth = birthmonth;
            Birthyear = birthyear;
            Anniverday = anniverday;
            Annivermonth = annivermonth;
            Anniveryear = anniveryear;
           

        }

        public ContactData(string firstname, string lastname, string middlename, string nickname, string address, string home, string mobileNumber,
            string email, string email2, string email3, string homepage, string birthday, string birthmonth, string birthyear, string anniverday, string annivermonth, string anniveryear, string company)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            Nickname = nickname;
            Address = address;
            Home = home;
            MobileNumber = mobileNumber;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            Birthday = birthday;
            Birthmonth = birthmonth;
            Birthyear = birthyear;
            Anniverday = anniverday;
            Annivermonth = annivermonth;
            Anniveryear = anniveryear;
            Company = company;

        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
           
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode()*Lastname.GetHashCode();
        }

        public override string ToString()
        {
            // return "firstname=" + Firstname + "\nmiddlename"+Middlename+ "\nlastname=" +Lastname;
             //  return  Firstname +Lastname+Middlename;
            return (Firstname + Middlename  + Lastname + Nickname + Address + Home + MobileNumber + Email + Email2 + Homepage + Birthday 
                + Birthmonth +  Birthyear + Anniverday + Annivermonth + Anniveryear);

        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
         

            if (Firstname == other.Firstname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
          
            return Firstname.CompareTo(other.Firstname);
        }

        public ContactData(string firstname)

        {
            Firstname = firstname;

        }
        [Column(Name = "firstname")]
        public string Firstname { get; set;  }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }



        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "bday")]
        public string Birthday { get; set; }
        [Column(Name = "bmonth")]
        public string Birthmonth { get; set; }
        [Column(Name = "byear")]
        public string Birthyear { get; set; }

        [Column(Name = "aday")]
        public string Anniverday { get; set; }
        [Column(Name = "amonth")]
        public string Annivermonth { get; set; }
        [Column(Name = "ayear")]
        public string Anniveryear { get; set; }
        [Column(Name = "title")]
        public string Title
        {
            get
            {

                return title;

            }

            set
            {
                title = value;
            }
        }
        [Column(Name = "company")]
        public string Company
        {
            get
            {

                return company;

            }

            set
            {
                company = value;
            }
        }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Home { get; set; }
        [Column(Name = "mobile")]
        public string MobileNumber { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "work")]
        public string WorkNumber { get; set; }


        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }


        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(MobileNumber) + CleanUp(WorkNumber)).Trim();
                }
            }

            set 
            {
                allPhones = value;
            } 
        }

   
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    //return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                    string[] emails = new[] { Email, Email2, Email3 };
                    string Test = string.Join("\r\n", emails.Where(test =>!String.IsNullOrEmpty(test)));

                    return Test;
                   // return  ((Email) +(Email2) + (Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        public string AllContacts
        {
            get
            {
                if (allContacts != null)
                {
                    return allContacts;
                }
                else
                {
                   
                    string[] contacts = new[] { Firstname, Middlename, Lastname, Nickname };
                    string Test = string.Join(" ", contacts.Where(test => !String.IsNullOrEmpty(test)));

                    return Test;
                    
                }
            }

            set
            {
                allContacts = value;
            }
        }


        private string CleanUp(string home)
        {
            if (home == null || home =="")
            {
                return "";
            }
            return Regex.Replace(home, "[ -()]", "") + "\r\n";
                   //home.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

      /*  public static List<ContactData> GetContactsAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=>x.Deprecated== "0000-00-00 00:00:00") select c).ToList();
            }
        }*/

        public static List<ContactData> GetContactsAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
              
                return (from c in db.Contacts select c).ToList();
            }
        }


        public static List<ContactData> GetContactsGroup(string GroupID)
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == GroupID && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}
