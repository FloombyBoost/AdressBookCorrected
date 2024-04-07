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
            OpenHomePage();
            LogOn(new AccountData("admin", "secret"));
            GoToGroupPage();
            RemoveGroup();
            ReturnGroupPage();
            LogOut();

        }

       





    }
}
