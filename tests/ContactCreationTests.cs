using AdressBook_web_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace AdressBook_web_test
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
      
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(15))
                {
                    Address = GenerateRandomString(20),
                    Email2 = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(12)
                });




            }
            return contact;
        }


        public static IEnumerable<ContactData> GroupDataFromCsvFile()
        {
            List<ContactData> contact = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contact.Add(new ContactData(parts[0], parts[1])
                {
                    WorkPhone = parts[2]
                   
                });
            }

            return contact;

        }




        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
               .Deserialize(new StreamReader(@"contacts.xml"));


        }


        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));


        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contact = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), "contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contact.Add(new ContactData()
                {
                    Address = range.Cells[i, 1].Value,
                    Email2 = range.Cells[i, 2].Value,
                    WorkPhone = range.Cells[i, 3].Value

                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contact;


        }

       
        [Test, TestCaseSource("RandomContactDataProvider")]//15 задание
        public void ContactCreationTestDataDriven(ContactData contact)
        {


            /*
              GroupData group = new GroupData("AAAN");
              group.Header = "aaa";
              group.Footer = "GroupFooterTest3";
            */
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);

            ClassicAssert.AreEqual(oldContacts.Count + 1, app.Contact.Count());
         
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);



        }


        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Evgenii03", "Emelianov");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);

            ClassicAssert.AreEqual(oldContacts.Count + 1, app.Contact.Count());


            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);


        }


    }
}
