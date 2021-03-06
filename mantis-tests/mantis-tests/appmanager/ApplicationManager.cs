using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected ProjectHelper projectHelper;
        protected NewNavigationHelper newNavigation;
        protected NewLoginHelper newLoginHelper;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get;  set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API= new APIHelper(this);
            projectHelper = new ProjectHelper(driver, applicationManager: this);
            newNavigation = new NewNavigationHelper(driver,this);
            newLoginHelper = new NewLoginHelper(driver, this);

        }

         ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
              
            }
        }

        public static ApplicationManager GetInstance() 
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
               
            }
            return app.Value;
        }
        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }

        public ProjectHelper Projects
        {
            get
            {
                return projectHelper;
            }
        }

        public NewNavigationHelper NewNavigation
        {
            get
            {
                return newNavigation;
            }
        }

        public NewLoginHelper NewLogin
        {
            get
            {
                return newLoginHelper;
            }
        }
    }
}
