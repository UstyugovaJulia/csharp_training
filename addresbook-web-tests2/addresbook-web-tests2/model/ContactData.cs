using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string title = "";
        private string company= "";
        private string allPhones;
        private string allEmails;
        private string otherN;

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

        public string Firstname { get; set;  }
        public string Lastname { get; set; }




        public string Middlename { get; set; }
       

        public string Nickname { get; set; }
        
        
       
        public string Birthday { get; set; }
        
        public string Birthmonth { get; set; }
       
        public string Birthyear { get; set; }
       

        public string Anniverday { get; set; }
        
        public string Annivermonth { get; set; }
        
        public string Anniveryear { get; set; }
        
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

        public string Address { get; set; }
        
        public string Home { get; set; }
        
        public string MobileNumber { get; set; }
       



        public string WorkNumber { get; set; }
        


        public string Email { get; set; }
        
        public string Email2 { get; set; }
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

        public string OtherN
        {
            get
            {
                if (OtherN != null)
                {
                    return OtherN;
                }
                else
                {
                    return (CleanUp(Firstname)).Trim();
                }
            }

            set
            {
                otherN = value;
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


        private string CleanUp(string home)
        {
            if (home == null || home =="")
            {
                return "";
            }
            return Regex.Replace(home, "[ -()]", "") + "\r\n";
                   //home.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }


        

        public string Homepage { get; set; }
        
    }
}
