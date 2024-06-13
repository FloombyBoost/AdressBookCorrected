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
    public class GropeRemove : GroupTestBase
    {
        

        [Test]
        public void TheGropeRemove()//Новое удаление задание 8
        {
            for (int i = 0; i < 40; i++)
            {

                int NumberGropeDelete = i;
                app.Navigator.GoToGroupPage();

                if (!app.Group.IsSelectGroup(NumberGropeDelete))//Если  НЕ находим группу генерируем новые
                {
                    app.Group.AutoGenerationGrope(NumberGropeDelete);
                }
                List<GroupData> oldGroups = GroupData.GetAll();
                GroupData toBeRemoved = oldGroups[NumberGropeDelete];

                app.Group.Remove(toBeRemoved);

                ClassicAssert.AreEqual(oldGroups.Count - 1, app.Group.Count());

                List<GroupData> newGroups = GroupData.GetAll();
                // GroupData toBeRemoved = oldGroups[NumberGropeDelete];
                oldGroups.RemoveAt(NumberGropeDelete);
                oldGroups.Sort();
                newGroups.Sort();
                ClassicAssert.AreEqual(oldGroups, newGroups);
                foreach (GroupData group in newGroups)
                {
                    ClassicAssert.AreNotEqual(group.Id, toBeRemoved.Id);
                }

            }

            //manager.Auth.LogOut();

        }






        






        
    }
    
}
