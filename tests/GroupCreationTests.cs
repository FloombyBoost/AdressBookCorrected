using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
namespace AdressBook_web_test
{
   [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
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




        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            
             return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
           

        }


        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));


        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb =app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1;i <= range.Rows.Count;i++) 
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value

                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;


        }

        [Test,TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {
            
           
          /*
            GroupData group = new GroupData("AAAN");
            group.Header = "aaa";
            group.Footer = "GroupFooterTest3";
          */
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Group.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count +1, app.Group.Count());

            List<GroupData> newGroups = GroupData.GetAll();
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

        [Test]
        public void TestDBConnectivity() 
        {
             DateTime start = DateTime.Now;
            List<GroupData> fromUI  = app.Group.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));


             start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();



            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }






    }
}
