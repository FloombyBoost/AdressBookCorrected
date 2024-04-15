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
    public class NavigatorHelper : HelperBase
        
    {
        
        protected string baseURL;
        public NavigatorHelper(ApplicationManager manager,string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }





   


        public void GoToGroupPage()
        {
            //go to group page
            driver.FindElement(By.Id("header")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
        }


        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
