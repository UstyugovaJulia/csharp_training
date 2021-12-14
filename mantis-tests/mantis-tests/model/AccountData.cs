﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AccountData
    {

        private string name;
        private string password;
        private string email;

        public AccountData(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public string Name

        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password

        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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
        /*   public string Name { get; set; }
           public string Password { get; set; }*/
     //   public string Email { get; set; }


        public AccountData(string name, string password,string email)
        {
            this.name = name;
            this.password = password;
            this.email = email;
        }
        public AccountData() { }

    }


}
