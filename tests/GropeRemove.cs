﻿using System;
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
            
            
            int NumberGropeDelete = 8;
            app.Navigator.GoToGroupPage();
            
            if (!app.Group.IsSelectGroup(NumberGropeDelete))//Если  НЕ находим группу генерируем новые
            {
                app.Group.AutoGenerationGrope(NumberGropeDelete);
                List<GroupData> oldGroups = app.Group.GetGroupList();
                app.Group.Remove(NumberGropeDelete);

                ClassicAssert.AreEqual(oldGroups.Count - 1, app.Group.Count());

                List<GroupData> newGroups = app.Group.GetGroupList();
                GroupData toBeRemoved = oldGroups[NumberGropeDelete];
                oldGroups.RemoveAt(NumberGropeDelete);
                oldGroups.Sort();
                newGroups.Sort();
                ClassicAssert.AreEqual(oldGroups, newGroups);
                foreach (GroupData group in newGroups)
                {
                    ClassicAssert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }
            else 
            {
                List<GroupData> oldGroups = app.Group.GetGroupList();
                app.Group.Remove(NumberGropeDelete);

                ClassicAssert.AreEqual(oldGroups.Count - 1, app.Group.Count());

                List<GroupData> newGroups = app.Group.GetGroupList();
                GroupData toBeRemoved = oldGroups[NumberGropeDelete];
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
