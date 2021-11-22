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
       // private string firstname;
      //  private string middlename="";
      //  private string lastname ="";
        private string nickname="";
        private string birthday = "";
        private string birthmonth = "";
        private string birthyear = "";
        private string anniverday = "";
        private string annivermonth = "";
        private string anniveryear = "";
        private string title = "";
        private string company= "";
        //private string address = "";
        private string home = "";
      //  private string mobileNumber = "";
       // private string workNumber = "";
       // private string email = "";
       // private string email2 = "";
        private string homepage = "";
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname,string middlename)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
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
            //   return "firstname=" + Firstname + " "+Middlename+ " "+Lastname;
               return Firstname+" "+Middlename+" "+Lastname;

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
        /*{
            get
            {

                return middlename;

            }

            set
            {
                middlename = value;
            }
        }*/

      /*  public string Lastname
        {
            get
            {

                return lastname;

            }

            set
            {
                lastname = value;
            }
        }*/

        public string Nickname
        {
            get
            {

                return nickname;

            }

            set
            {
                nickname = value;
            }
        }
        
       
        public string Birthday
        {
            get
            {

                return birthday;

            }

            set
            {
                birthday = value;
            }
        }

        public string Birthmonth
        {
            get
            {

                return birthmonth;

            }

            set
            {
                birthmonth = value;
            }
        }

        public string Birthyear
        {
            get
            {

                return birthyear;

            }

            set
            {
                birthyear = value;
            }
        }

       
       

        public string Anniverday
        {
            get
            {

                return anniverday;

            }

            set
            {
                anniverday = value;
            }
        }

        public string Annivermonth
        {
            get
            {

                return annivermonth;

            }

            set
            {
                annivermonth = value;
            }
        }

        public string Anniveryear
        {
            get
            {

                return anniveryear;

            }

            set
            {
                anniveryear = value;
            }
        }

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
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
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

      //  public string AllEmails { get; set; }


        public string Homepage
        {
            get
            {

                return homepage;

            }

            set
            {
                homepage = value;
            }
        }

    }
}
