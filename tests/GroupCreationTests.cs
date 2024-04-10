using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogOn(new AccountData ( "admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Group.InitGroupCreation();
            GroupData group = new GroupData("NameGroupTest");
            group.Header = "GroupHeaderTest";
            group.Footer = "GroupFooterTest";
            app.Group.FillGroupForm(group);
            app.Group.SubmitGroupCreation();
            app.Group.ReturnGroupPage();
            app.Auth.LogOut();
        }

     
       
        

        

    }
}
