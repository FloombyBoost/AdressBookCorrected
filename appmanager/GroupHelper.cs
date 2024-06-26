﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
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
            GroupCache = null;
            return this;
        }



        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnGroupPage();
            //manager.Auth.LogOut();
            return this;
        }

        public void AutoGenerationGrope(int untillNumber)
        {
            int CountAddGrope = 1;
            while (!IsSelectGroup(untillNumber))
            {
                //if (untillNumber == 0) break;


                manager.Navigator.GoToGroupPage();
                InitGroupCreation();
                FillGroupForm(new GroupData($"AddNewGrope{CountAddGrope}"));
                SubmitGroupCreation();
                ReturnGroupPage();
                CountAddGrope++;
            }
        }

       



        public GroupHelper Remove(int v)
        {

            manager.Navigator.GoToGroupPage();
            
                SelectGroup(v);
                RemoveGroup();
                ReturnGroupPage();
                //manager.Auth.LogOut();
            
            
            return this;
        }

        public void Remove(GroupData group)
        {

            manager.Navigator.GoToGroupPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnGroupPage();
            //manager.Auth.LogOut();


           
        }


        public GroupHelper SelectGroup(int v)
        {
            driver.FindElement(By.XPath($"//div[@id='content']/form/span[{v + 1}]/input")).Click();
            return this;
        }


        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }


        public bool IsSelectGroup(int v)
        {
            return IsElementPresent(By.XPath($"//div[@id='content']/form/span[{v+1}]/input"));
        }

        public GroupHelper Modify(string id, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            

                SelectGroup(id);
                InitGroupModify();
                FillGroupForm(newData);
                SubmitGroupModify();
                ReturnGroupPage();
            
            
            return this;
        }

        private GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.Name("update")).Click();
            GroupCache = null;
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
            //driver.FindElement(By.Name("group_name")).Click();
      
            Type(By.Name("group_name"), group.Name);
            //Type(By.Name("group_header"), group.Header);   //если снять комент-тест будет падать
            //Type(By.Name("group_footer"), group.Footer);   //если снять комент-тест будет падать
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
            GroupCache = null;
            return this;
        }

       
        public GroupHelper ReturnGroupPage()
        {
            //return to group page
            driver.FindElement(By.LinkText("groups")).Click();
            return this ;
        }
        private List<GroupData> GroupCache = null;

        public List<GroupData> GetGroupList()
        {
             if (GroupCache == null)
            {
                GroupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {



                    //GroupCache.Add(new GroupData(element.Text) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") }); обращаемся каждый раз к браузеру за текстом
                    GroupCache.Add(new GroupData(null) { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });//оптимизация
                }
                string AllGroupName = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = AllGroupName.Split('\n');
                int shift = GroupCache.Count - parts.Length;
                for (int i = 0; i < GroupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        GroupCache[i].Name = "";
                    }
                    else
                    {
                        GroupCache[i].Name = parts[i-shift].Trim();
                    }
                }
            }

            return new List<GroupData>(GroupCache);
        }

        public int Count()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
