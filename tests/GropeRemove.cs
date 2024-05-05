using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GropeRemove : AuthTestBase
    {
        

        [Test]
        public void TheGropeRemove( int v)//
        {
            // ERROR: Caught exception [unknown command []]

            if (app.Group.IsSelectGroup(v))
            {
                app.Group.Remove(v);
            }

            else
            {

                app.Navigator.GoToGroupPage();
               app.Group.InitGroupCreation();
                app.Group.FillGroupForm(new GroupData("NewGrop"));
                app.Group.SubmitGroupCreation();
                app.Group.ReturnGroupPage();
                //manager.Auth.LogOut();
                Remove(v);
            }
            return this;


            app.Group.Remove(4);






            public GroupHelper Remove(int v)
            {

                manager.Navigator.GoToGroupPage();
                if (IsSelectGroup(v))
                {
                    SelectGroup(v);
                    RemoveGroup();
                    ReturnGroupPage();
                    manager.Auth.LogOut();
                }
                else
                {

                    manager.Navigator.GoToGroupPage();
                    InitGroupCreation();
                    FillGroupForm(new GroupData("NewGrop"));
                    SubmitGroupCreation();
                    ReturnGroupPage();
                    //manager.Auth.LogOut();
                    Remove(v);
                }
                return this;
            }








        }

       





    }
}
