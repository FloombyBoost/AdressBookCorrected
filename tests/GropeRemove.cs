using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.DevTools.V121.Debugger;
using OpenQA.Selenium.DevTools.V121.DOM;


namespace AdressBook_web_test
{
    [TestFixture]
    public class GropeRemove : AuthTestBase
    {
        

        [Test]
        public void TheGropeRemove()//Новое удаление задание 8
        {
            
            
            int NumberGropeDelete = 2;
            app.Navigator.GoToGroupPage();
            
            if (!app.Group.IsSelectGroup(NumberGropeDelete))//Если  НЕ находим группу генерируем новые
            {
                app.Group.AutoGenerationGrope(NumberGropeDelete);
                app.Group.IsCorrectedGroupRemove(NumberGropeDelete);
                
            }
            else 
            {
                app.Group.IsCorrectedGroupRemove(NumberGropeDelete);


            }



            //manager.Auth.LogOut();

        }






        






        
    }
    
}
