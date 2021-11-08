using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename="";
        private string lastname ="";
        private string nickname="";
        private string birthday = "";
        private string birthmonth = "";
        private string birthyear = "";
        private string anniverday = "";
        private string annivermonth = "";
        private string anniveryear = "";
        private string title = "";
        private string company= "";
        private string address = "";
        private string home = "";
        private string mobileNumber = "";
        private string workNumber = "";
        private string email = "";
        private string email2 = "";
        private string homepage = "";


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
            return Lastname == other.Lastname;
                //&& Middlename == other.Middlename;
            //return Middlename == other.Middlename;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() ;
        }

        public override string ToString()
        {
            return "lastname="+Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public ContactData(string firstname)
           
        {
            this.firstname = firstname;
         
           

        }

        public string Firstname 
        {
            get {

                return firstname;

            }

            set {
                firstname = value;
            }
        }

        
       

        public string Middlename
        {
            get
            {

                return middlename;

            }

            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {

                return lastname;

            }

            set
            {
                lastname = value;
            }
        }

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

        public string Address
        {
            get
            {

                return address;

            }

            set
            {
                address = value;
            }
        }

        public string Home
        {
            get
            {

                return home;

            }

            set
            {
                home = value;
            }
        }

        public string MobileNumber
        {
            get
            {

                return mobileNumber;

            }

            set
            {
                mobileNumber = value;
            }
        }




        public string WorkNumber
        {
            get
            {

                return workNumber;

            }

            set
            {
                workNumber = value;
            }
        }



        public string Email
        {
            get
            {

                return email;

            }

            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {

                return email2;

            }

            set
            {
                email2 = value;
            }
        }


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
