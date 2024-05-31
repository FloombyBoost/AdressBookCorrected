using AdressBook_web_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

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



        [Test, TestCaseSource("RandomContactDataProvider()")]
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
