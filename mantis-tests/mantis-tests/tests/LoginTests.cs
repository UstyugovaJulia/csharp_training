using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public  class LoginTests:TestBase
    {
        [Test]
        public void LoginWithValidCredentials() 
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account=new AccountData("administrator", "root");
            app.Auth.Login(account);

            //verification
            //Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

      
    }
}
