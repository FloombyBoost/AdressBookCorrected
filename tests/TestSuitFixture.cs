﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{
    [SetUpFixture] // НУЖНО УДАЛИТЬ ЭТУ ФИКСТУРУ d
    public class TestSuitFixture
    {
    

        [OneTimeSetUp]//[OneTimeSetUp]//SetUp
        public void InitApplicationManager()
        {
            ApplicationManager app =  ApplicationManager.GetInstanse();
           
            app.Auth.LogOn(new AccountData("admin", "secret"));
        }

       [OneTimeTearDown]//деструктор не работает значит паралельных запусков не будет
        public void StopApplicationManager()
        {
            ApplicationManager.GetInstanse().Stop();
        }

    }


}
