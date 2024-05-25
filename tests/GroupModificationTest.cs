using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{
    [TestFixture]
    public class GroupModificationTest : AuthTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            int NumberGropeModify = 5;
            app.Navigator.GoToGroupPage();
            GroupData newData = new GroupData("ModiFYGrope");
            newData.Header = "HeadNew";
            newData.Footer = "FooterNew";
            if (!app.Group.IsSelectGroup(NumberGropeModify))//Если не  находим группу модифицируем
            {
                app.Group.AutoGenerationGrope(NumberGropeModify);
                
            }
            //else // Если группу находим,добавляем необходимое кол-во групп. Исключение 0 группа ( антизацикливание)
            app.Group.Modify(NumberGropeModify, newData);
            int CountAddGrope = 1;

                
            


        }

    }
}
