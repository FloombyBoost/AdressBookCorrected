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
    public void TheContactRemove()//7
    {
            // ERROR: Caught exception [unknown command []]
            int NumberCotactDelete = 5;
            if (app.Contact.IsSelectContact(NumberCotactDelete))//Если находим контакт удаляем
            {
                app.Contact.Remove(NumberCotactDelete);
            }

            else // Если группу не находим,добавляем необходимое кол-во контактов. Исключение 0 контакт ( антизацикливание)
            {
                app.Contact.AutoGenerationContact(NumberCotactDelete);
                app.Contact.Remove(NumberCotactDelete);
            }


           


    }







}
}