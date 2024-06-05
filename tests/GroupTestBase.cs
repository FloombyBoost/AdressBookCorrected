using AdressBook_web_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
   public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (group_perfom_long_UI_checks)
            {
                List<GroupData> fromUI = app.Group.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                ClassicAssert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
