using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{
    internal class AccountData
    {
        private string username;
        private string password;
        


        public AccountData (string username , string password) 
        {
            this.username = username;
            this.password = password;//полю присваиваем параметр  this.password ЭТО ПОЛЕ
            
        }
        public string Username  // задаем свойства логина
        {
            get { return username; }
            set { username = value; }
        }


        public string Password // задаем свойства  пароля 
        {
            get { return password; }
            set { password = value; }
        }

    }
}
