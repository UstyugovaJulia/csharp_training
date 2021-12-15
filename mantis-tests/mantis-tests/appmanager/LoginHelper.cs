﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests

{
   public  class LoginHelper:HelperBase
    {
      

        public LoginHelper(ApplicationManager manager):base(manager) {

          
        }
        public  void Login(AccountData account)
        {
            if (IsLoggedIn()) 
            {
                if (IsLoggedIn(account)) 
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("username"), account.Name);
          //  Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@class='width-40 pull-right btn btn-success btn-inverse bigger-110']")).Click();
              Type(By.Name("password"), account.Password);

        }


        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
            
        }

         public bool IsLoggedIn(AccountData account)
         {
             return IsLoggedIn()
                 && GetLoggetUserName() == account.Name;

         }
      
         public string GetLoggetUserName()
         {
             string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
             return text.Substring(1,text.Length-2);
          //            == System.String.Format("(${0})", account.Username);
         }


    }
}
