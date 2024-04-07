﻿using AdressBook_web_test;
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
            OpenHomePage();
            LogOn(new AccountData("admin", "secret"));
            InitContactCreation();
            FillContactForm(new ContactData("Evgenii", "Emelianov"));
            SubmitContactCreation();
            SubmitHome();
        }

    }
}
