using AdressBook_web_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
            
        
        }

    }
}
