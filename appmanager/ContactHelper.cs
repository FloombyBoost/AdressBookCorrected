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
    
        public class ContactHelper : HelperBase
        {
           
            public ContactHelper(ApplicationManager manager) : base(manager)
        {
              
            }



        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            SubmitHome();
            return this;
        }

        public ContactHelper Modify(int n, ContactData newcontact)
        {

            //SelectContact(n);  как показывает практика выделение контакта перед изменением ничего не дает.Нужен конкретный клик по иконке
            InitContactModify(n);
            FillContactForm(newcontact);
            SubmitContactModify();
            SubmitHome();
            return this;
           
        }

        public ContactHelper SelectContact(int n)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1+n}]/td")).Click();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            SubmitContactRemove();

            return this;
        }

        public ContactHelper SubmitContactRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
           // driver.SwitchTo().Alert().Accept();// закрыть Алерт? какой алерт?
            return this;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

        public ContactHelper InitContactModify(int n)
        {
            // driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click(); первая иконка
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1+n}]/td[8]/a/img")).Click();  //все вроме первой, но возможно и первую найдет
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("middlename"), contact.LastName);
           
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public ContactHelper SubmitHome()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;

        }

       
    }

}
