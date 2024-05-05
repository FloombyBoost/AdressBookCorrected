using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
   [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            
           
          
            GroupData group = new GroupData("NameGroupTest");
            group.Header = "GroupHeaderTest";
            group.Footer = "GroupFooterTest";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            List<GroupData> newGroups = app.Group.GetGroupList();
            ClassicAssert.AreEqual(oldGroups.Count +1, newGroups.Count);    
            
            
        }


        [Test]
        public void EmptyGroupCreationTest()
        {

         
           
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            List<GroupData> newGroups = app.Group.GetGroupList();
            ClassicAssert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }

        [Test]
        public void BAdGroupCreationTest()
        {



            GroupData group = new GroupData("1s1s");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            List<GroupData> newGroups = app.Group.GetGroupList();
            ClassicAssert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }






    }
}
