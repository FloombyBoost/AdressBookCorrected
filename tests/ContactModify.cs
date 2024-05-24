using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{
   [TestFixture]
    public class ContactModificationTest : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {

            int NumberContactModify = 5;
            ContactData newcontact = new ContactData("NewJon111", "NewSnow111");
            if (app.Contact.IsSelectContact(NumberContactModify))//Если находим контакт удаляем
            {
                app.Contact.Modify(NumberContactModify, newcontact);

            }
            else
            {
                {
                    app.Contact.AutoGenerationContact(NumberContactModify);
                    app.Contact.Modify(NumberContactModify, newcontact);
                }
            }


            


        }

        
    }
}