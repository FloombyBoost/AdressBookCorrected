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
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
       

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void GoToGroupPage()
        {
            //go to group page
            driver.FindElement(By.Id("header")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void LogOn(AccountData account)
        {

            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }


        protected void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.LastName);
        }

        protected void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        protected void SubmitHome()
        {
            driver.FindElement(By.LinkText("home")).Click();

        }






        protected void ReturnGroupPage()
        {
            //return to group page
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void SubmitGroupCreation()
        {
            //Submit group creation
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            //Fill group form
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void InitGroupCreation()
        {
            //Init new group creation
            driver.FindElement(By.Name("new")).Click();
        }



       protected void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }


        protected void LogOut()
        {
            //Logout
              driver.FindElement(By.Name("new")).Click();
        }

        protected void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[3]/input")).Click();
            driver.FindElement(By.Name("delete")).Click();
        }





    }
}
