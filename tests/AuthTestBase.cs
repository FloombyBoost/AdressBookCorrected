﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {

            app.Auth.LogOn(new AccountData("admin", "secret"));

        }
    }
}
