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
            OpenHomePage();
            LogOn(new AccountData ( "admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("NameGroupTest");
            group.Header = "GroupHeaderTest";
            group.Footer = "GroupFooterTest";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnGroupPage();
            LogOut();
        }

     
       
        

        

    }
}
