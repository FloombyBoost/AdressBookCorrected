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
            GroupData newData = new GroupData("wdwd ");
            newData.Header = "HeadNew";
            newData.Footer = "FooterNew";
            app.Group.Modify(7, newData);

        }

    }
}
