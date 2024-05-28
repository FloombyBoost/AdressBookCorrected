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

            int NumberContactModify = 3;
            ContactData newcontact = new ContactData("NewJon111", "NewSnow111");
            


            if (!app.Contact.IsSelectContact(NumberContactModify))//Если находим контакт удаляем
            {
                app.Contact.AutoGenerationContact(NumberContactModify);
                List<ContactData> oldContacts = app.Contact.GetContactList();
                ContactData oldContactData = oldContacts[NumberContactModify];
                app.Contact.Modify(NumberContactModify, newcontact);

                ClassicAssert.AreEqual(oldContacts.Count, app.Contact.Count());

                List<ContactData> newContacts = app.Contact.GetContactList();
                oldContacts[NumberContactModify] = newcontact;
                oldContacts.Sort();
                newContacts.Sort();
                ClassicAssert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    if (contact.Id == oldContactData.Id)
                    {
                        ClassicAssert.AreEqual(newcontact.Name, contact.Name);
                        ClassicAssert.AreEqual(newcontact.LastName, contact.LastName);
                    }
                }
            }
            else
            {
                List<ContactData> oldContacts = app.Contact.GetContactList();
                ContactData oldContactData = oldContacts[NumberContactModify];
                app.Contact.Modify(NumberContactModify, newcontact);

                ClassicAssert.AreEqual(oldContacts.Count, app.Contact.Count());

                List<ContactData> newContacts = app.Contact.GetContactList();
                oldContacts[NumberContactModify]= newcontact;
                oldContacts.Sort();
                newContacts.Sort();
                ClassicAssert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {
                    if (contact.Id == oldContactData.Id)
                    {
                        ClassicAssert.AreEqual(newcontact.Name, contact.Name);
                        ClassicAssert.AreEqual(newcontact.LastName, contact.LastName);
                    }
                }
            }


        }

        
    }
}