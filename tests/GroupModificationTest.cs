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
    public class GroupModificationTest : GroupTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            int NumberGropeModify = 15;
            app.Navigator.GoToGroupPage();
            GroupData newData = new GroupData("ModiFYGrope");
            newData.Header = "HeadNew";
            newData.Footer = "FooterNew";
            if (!app.Group.IsSelectGroup(NumberGropeModify))//Если не  находим группу модифицируем
            {
                app.Group.AutoGenerationGrope(NumberGropeModify);
                              }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[NumberGropeModify];
            app.Group.Modify(oldData.Id, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Group.Count());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[NumberGropeModify] = newData;

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
