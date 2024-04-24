using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{
   // [TestFixture]
    public class ContactModificationTest : TestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newcontact = new ContactData("NewJon111", "NewSnow111");
            app.Contact.Modify(1, newcontact);//будет работать со всеми кроме первого контакта!


        }

        
    }
}