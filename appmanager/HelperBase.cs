using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace AdressBook_web_test
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager  manager)

        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (locator != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public void AutoenerateGroupContact(List<GroupData> groupListData, List<ContactData> contacttList )
        {
            if (groupListData.Count == 0)
            {
                GroupData group = new GroupData("GroupAuto" + GenerateRandomString(3));
                group.Header = "";
                group.Footer = "";
                 manager.Group.Create(group);
            }
            if (contacttList.Count == 0)
            {
                ContactData contact = new ContactData("FirstName" + GenerateRandomString(2), "LastName" + GenerateRandomString(3));
                manager.Contact.Create(contact);
            }

        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 60)));
            }
            return builder.ToString();
            throw new NotImplementedException();
        }



        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}