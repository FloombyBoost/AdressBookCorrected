using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;

namespace AdressBook_web_test
{
   [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for(int i = 0;i< 5;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                { Footer = GenerateRandomString(100),
                  Header = GenerateRandomString(100)
                });

                
                

            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach ( string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                 Header = parts[1],
                 Footer = parts[2]
                });
            }

            return groups;

        }

        [Test,TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {
            
           
          /*
            GroupData group = new GroupData("AAAN");
            group.Header = "aaa";
            group.Footer = "GroupFooterTest3";
          */
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count +1, app.Group.Count());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups, newGroups);    
            
            
        }


        /*

        [Test]
        public void EmptyGroupCreationTest()
        {

         
           
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Group.Count());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
        */

        [Test]
        public void BAdGroupCreationTest()
        {



            GroupData group = new GroupData("1s'1s");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Group.Count());


            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            ClassicAssert.AreEqual(oldGroups, newGroups);

        }






    }
}
