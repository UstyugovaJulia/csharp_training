using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            //driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
            //  driver.FindElements(By.CssSelector("div a.back-to-login-link pull-left"))[0].Click();
            //  driver.FindElement(By.CssSelector("div a.back-to-login-link pull-left")).Click();
            driver.FindElement(By.XPath("//a[@class='back-to-login-link pull-left']")).Click();
            //back-to-login-link pull-left
        }

        private void SubmitRegistration()
        {
         //   driver.FindElement(By.CssSelector("input")).Click();
            driver.FindElement(By.XPath("//input[@class='width-40 pull-right btn btn-success btn-inverse bigger-110']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
        }
    }
}
