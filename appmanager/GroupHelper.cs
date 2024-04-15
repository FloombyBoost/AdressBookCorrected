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
       
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
          
        }



        public GroupHelper SubmitGroupCreation()
        {
            //Submit group creation
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }



        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnGroupPage();
            manager.Auth.LogOut();
            return this;
        }


        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnGroupPage();
            manager.Auth.LogOut();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModify();
            FillGroupForm(newData);
            SubmitGroupModify();
            ReturnGroupPage();
            return this;
        }

        private GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModify()
        {
            
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
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
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            //Init new group creation
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int v)
        {
            driver.FindElement(By.XPath($"//div[@id='content']/form/span[{v}]/input")).Click();
            return this;
        }

        public GroupHelper ReturnGroupPage()
        {
            //return to group page
            driver.FindElement(By.LinkText("groups")).Click();
            return this ;
        }

     
    }
}
