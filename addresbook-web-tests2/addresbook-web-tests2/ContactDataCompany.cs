using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactDataCompany
    {

        private string title="";
        private string company;
        private string address="";
        private string home = "";
        private string mobileNumber = "";
        private string workNumber = "";
        private string email = "";
        private string email2 = "";
        private string homepage = "";

        public ContactDataCompany (string company)
          
        {
           
            this.company = company;
        


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
