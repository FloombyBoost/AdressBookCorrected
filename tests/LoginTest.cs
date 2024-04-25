using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;


namespace AdressBook_web_test
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials() 
        {
            //prepare
            app.Auth.LogOut();
            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.LogOn(account);
            //verification
            ClassicAssert.IsTrue(app.Auth.IsLoggedIn(account));
        }


        [Test]
        public void LoginWithInValidCredentials()
        {
            //prepare
            app.Auth.LogOut();
            //action
            AccountData account = new AccountData("admin", "notValidPassword");
            app.Auth.LogOn(account);
            //verification
            ClassicAssert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
