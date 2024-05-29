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
                app.Group.IsCorrectedGroupModify(NumberGropeModify, newData);




            }
            else //
            {
                app.Group.IsCorrectedGroupModify(NumberGropeModify, newData);

            }
           

                
            


        }

    }
}
