using System;
using System.Collections.Generic;
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
            
            
            int NumberGropeDelete = 3;
            app.Navigator.GoToGroupPage();
            if (!app.Group.IsSelectGroup(NumberGropeDelete))//Если  НЕ находим группу генерируем новые
            {
                app.Group.AutoGenerationGrope(NumberGropeDelete);
               // List<GroupData> oldGroups = app.Group.GetGroupList();  будет доработано в 9 задании

            }
            //else в 9 задании будет создан блок else 
          //  {
         //       List<GroupData> oldGroups = app.Group.GetGroupList(); начало 9 задания

         //   }
           

            List<GroupData> newGroups = app.Group.GetGroupList();
            app.Group.Remove(NumberGropeDelete);
          //  oldGroups.RemoveAt(NumberGropeDelete);
           // ClassicAssert.AreEqual(oldGroups, newGroups);

            //manager.Auth.LogOut();

        }






        






        
    }
    
}
