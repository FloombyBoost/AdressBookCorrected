using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdressBook_web_test
{ 

[TestFixture]
public class ContactRemove : AuthTestBase
    {


    [Test]
    public void TheContactRemove()//7===e
    {
        // ERROR: Caught exception [unknown command []]
        app.Contact.Remove(4);


    }







}
}