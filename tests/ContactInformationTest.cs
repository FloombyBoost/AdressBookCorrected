using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
namespace AdressBook_web_test
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {

        [Test]
        public void TestContactInformation ()
        {
            int index = 1;
            ContactData fromTable = app.Contact.GetContactInformationFromTable(index);
            ContactData fromForm = app.Contact.GetContactInformationFromEdit(index);

            ClassicAssert.AreEqual(fromTable, fromForm);
            ClassicAssert.AreEqual(fromTable.Address, fromForm.Address);
            ClassicAssert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            ClassicAssert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformation2()
        {
            int index = 5;
            string fromInfo = app.Contact.GetContactInformationFromInfo(index);
            ContactData fromForm = app.Contact.GetContactInformationFromEdit(index);
           
         

            ClassicAssert.AreEqual(fromInfo, fromForm.AllInfo);
           
        }
    }
}
