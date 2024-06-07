using AdressBook_web_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{ 
    public class ContactTestBase : AuthTestBase
    {


        [TearDown]
        public void CompareContactUI_DB()
        {
            if (contact_perfom_long_UI_checks)
            {
                List<ContactData> fromUI = app.Contact.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                ClassicAssert.AreEqual(fromUI,fromDB);
            }

        }




    }





}


