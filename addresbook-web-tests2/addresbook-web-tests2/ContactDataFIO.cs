using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactDataFIO
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
        
       
        public ContactDataFIO(string firstname)
           
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
    }
}
