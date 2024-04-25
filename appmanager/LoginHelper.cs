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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    
                        return;
                    
                }
                LogOut();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text ==
                "(" + account.Username + ")";
            //throw new NotImplementedException();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
            //throw new NotImplementedException();
        }

        public void LogOut()
        {
            if (IsLoggedIn()) 
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            //Logout
            
        }



    }
}
