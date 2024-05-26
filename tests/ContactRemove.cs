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
public class ContactRemove : AuthTestBase
    {


    [Test]
    public void TheContactRemove()//7===e1
    {
            // ERROR: Caught exception [unknown command []]
            int NumberContactDelete = 0;
            if (!app.Contact.IsSelectContact(NumberContactDelete))//Если находим контакт удаляем
            {
                app.Contact.AutoGenerationContact(NumberContactDelete);
                List<ContactData> oldContacts = app.Contact.GetContactList();
                app.Contact.Remove(NumberContactDelete);
              
                List<ContactData> newContacts = app.Contact.GetContactList();
               
                oldContacts.RemoveAt(NumberContactDelete);
                oldContacts.Sort();
                newContacts.Sort();
                ClassicAssert.AreEqual(oldContacts, newContacts);
            }
            else
            {
                List<ContactData> oldContacts = app.Contact.GetContactList();
                app.Contact.Remove(NumberContactDelete);
               
                List<ContactData> newContacts = app.Contact.GetContactList();
               
                oldContacts.RemoveAt(NumberContactDelete);
                oldContacts.Sort();
                newContacts.Sort();
                ClassicAssert.AreEqual(oldContacts, newContacts);
            }



        }







    }
}