using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdressBook_web_test
{
    public class LoginHelper : HelperBase
    {
         
        public LoginHelper(ApplicationManager manager)  : base(manager)
        {
            
        }
        public void LogOn(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }

        public void LogOut()
        {
            //Logout
            driver.FindElement(By.Name("new")).Click();
        }



    }
}
