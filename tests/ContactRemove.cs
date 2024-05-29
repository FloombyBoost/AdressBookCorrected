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
            int NumberContactDelete =15;
            if (!app.Contact.IsSelectContact(NumberContactDelete))//Если находим контакт удаляем
            {
                app.Contact.AutoGenerationContact(NumberContactDelete);
                app.Contact.IsCorrectedRemoveContact(NumberContactDelete);

            }
            else
            {
                app.Contact.IsCorrectedRemoveContact(NumberContactDelete);
            }



        }







    }
}