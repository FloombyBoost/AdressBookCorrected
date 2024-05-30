using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GroupModificationTest : AuthTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            int NumberGropeModify =23;
            app.Navigator.GoToGroupPage();
            GroupData newData = new GroupData("ModiFYGrope");
            newData.Header = "HeadNew";
            newData.Footer = "FooterNew";
            if (!app.Group.IsSelectGroup(NumberGropeModify))//Если не  находим группу модифицируем
            {
                app.Group.AutoGenerationGrope(NumberGropeModify);
                              }
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData oldData = oldGroups[NumberGropeModify];
            app.Group.Modify(NumberGropeModify, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Group.Count());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[NumberGropeModify].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.Name, group.Name);
                }
            }






        }

    }
}
