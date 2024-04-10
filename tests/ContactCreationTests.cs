using AdressBook_web_test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace AdressBook_web_test
{
    [TestFixture]
    public class ContactCreationTests : TestBase 
    {
       
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.LogOn(new AccountData("admin", "secret"));
            app.Contact.InitContactCreation();
            app.Contact.FillContactForm(new ContactData("Evgenii", "Emelianov"));
            app.Contact.SubmitContactCreation();
            app.Contact.SubmitHome();
        }

    }
}
