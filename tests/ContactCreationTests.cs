using AdressBook_web_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace AdressBook_web_test
{
    //[TestFixture]
    public class ContactCreationTests : TestBase 
    {
       
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Evgenii03", "Emelianov");
            app.Contact.Create(contact);
        
        }

    }
}
