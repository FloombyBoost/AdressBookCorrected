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
            
           
          
            GroupData group = new GroupData("NameGroupTest");
            group.Header = "GroupHeaderTest";
            group.Footer = "GroupFooterTest";
            app.Group.Create(group);
            
        }


        [Test]
        public void EmptyGroupCreationTest()
        {

         
           
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Group.Create(group);
            
        }







    }
}
