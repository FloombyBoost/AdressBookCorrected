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
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {

            int NumberContactModify =10;
            ContactData newcontact = new ContactData("NewJon111", "NewSnow111");
            


            if (!app.Contact.IsSelectContact(NumberContactModify))//Если находим контакт удаляем
            {
                app.Contact.AutoGenerationContact(NumberContactModify);
                app.Contact.IsCorrectedModifyContact(NumberContactModify,newcontact);
                
            }
            else
            {
                app.Contact.IsCorrectedModifyContact(NumberContactModify, newcontact);
            }


        }

        
    }
}