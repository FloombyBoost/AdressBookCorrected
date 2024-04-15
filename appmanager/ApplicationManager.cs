using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AdressBook_web_test
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigatorHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
         protected string baseURL;

        public ApplicationManager()
        {
            baseURL = "http://localhost/addressbook";
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(this);
            navigator = new NavigatorHelper(this,baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            
        }

        public IWebDriver Driver 
        {
            get { return driver; }
            
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        

        public LoginHelper Auth 
        {
            get {  return loginHelper; }     
        }
        public NavigatorHelper Navigator 
        {
            get { return navigator; }
        }

        public GroupHelper Group 
        {
            get { return groupHelper; }

        }

        public ContactHelper Contact 
        {
            get { return contactHelper; }
        }

        
    }
}
