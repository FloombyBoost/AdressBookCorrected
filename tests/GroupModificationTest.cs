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
            if (app.Group.IsSelectGroup(NumberGropeModify))//Если находим группу модифицируем
            {
               
                app.Group.Modify(NumberGropeModify, newData);
            }
            else // Если группу не находим,добавляем необходимое кол-во групп. Исключение 0 группа ( антизацикливание)
            {
                int CountAddGrope = 1;

                app.Group.AutoGenerationGrope(NumberGropeModify);
                app.Group.Modify(NumberGropeModify, newData);
            }


        }

    }
}
