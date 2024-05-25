using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
   [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            
           
          
            GroupData group = new GroupData("AAAN");
            group.Header = "aaa";
            group.Footer = "GroupFooterTest3";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups, newGroups);    
            
            
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



            GroupData group = new GroupData("1s'1s");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);
            List<GroupData> newGroups = app.Group.GetGroupList();
            ClassicAssert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }






    }
}
