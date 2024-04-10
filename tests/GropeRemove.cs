using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GropeRemove : TestBase
    {
        

        [Test]
        public void TheGropeRemove()//
        {
            // ERROR: Caught exception [unknown command []]
            app.Navigator.OpenHomePage();
            app.Auth.LogOn(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Group.RemoveGroup();
            app.Group.ReturnGroupPage();
            app.Auth.LogOut();

        }

       





    }
}
