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
    public class GroupHelper : HelperBase
    {
       
        public GroupHelper(IWebDriver driver) : base(driver)
        {
          
        }



        public void SubmitGroupCreation()
        {
            //Submit group creation
            driver.FindElement(By.Name("submit")).Click();
        }










        public void FillGroupForm(GroupData group)
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

        public void InitGroupCreation()
        {
            //Init new group creation
            driver.FindElement(By.Name("new")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[3]/input")).Click();
            driver.FindElement(By.Name("delete")).Click();
        }

        public void ReturnGroupPage()
        {
            //return to group page
            driver.FindElement(By.LinkText("groups")).Click();
        }



    }
}
