using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V121.Debugger;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GropeRemove : AuthTestBase
    {
        

        [Test]
        public void TheGropeRemove()//Новое удаление задание 8
        {
            
            int NumberGropeDelete = 5;
            app.Navigator.GoToGroupPage();
            if (app.Group.IsSelectGroup(NumberGropeDelete))//Если находим группу удаляем
            {
                app.Group.Remove(NumberGropeDelete);
            }

            else // Если группу не находим,добавляем необходимое кол-во групп. Исключение 0 группа ( антизацикливание)
            {
                app.Group.AutoGenerationGrope(NumberGropeDelete);
                app.Group.Remove(NumberGropeDelete);
            }
            
            //manager.Auth.LogOut();

        }






        






        
    }
    
}
