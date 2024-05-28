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
