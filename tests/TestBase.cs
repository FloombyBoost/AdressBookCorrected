﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AdressBook_web_test
{
    public class TestBase
    {
      
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
           
            app = new ApplicationManager();

        }

        [TearDown]
        public void TeardownTest()
        {
            
          app.Stop();
        }

      

      


       
        


       



        





    }
}