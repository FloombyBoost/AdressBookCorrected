using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
    public class AddingContactsToGroupTest : AuthTestBase
    {

        [Test]

        public void AddingContactToGroup()
        {
             List <GroupData> groupListData = GroupData.GetAll();
            for (int i = 0; i < groupListData.Count; i++)
            {
                GroupData group = groupListData[i];
                List<ContactData> oldList = group.GetContacts();

                try
                {
                    ContactData contactForExep = ContactData.GetAll().Except(oldList).First();//Если нет контактов для добавления в i =0  группе

                }
                catch
                {
                    continue;// тогда проверяем другую группу
                }
                ContactData contact = ContactData.GetAll().Except(oldList).First();//в блоке try  исключение не возникло==>1 контакт точно есть
                app.Contact.AddcontactToGroup(contact, group);

               List<ContactData> newList = group.GetContacts();
               oldList.Add(contact);
                newList.Sort();
                oldList.Sort();
                ClassicAssert.AreEqual(oldList, newList);
                break;
                
                
                //Хотел реализовать аналогично RemoveContacn  но получил ошибку преобразования для 46 строки

                //List<ContactData> ContactsNotInGroupList = (List <ContactData>) ContactData.GetAll().Except(oldList);--ЭТА строка вызвала ошибку преобразования-не понял почему
                //ContactData contact  = ContactsNotInGroupList.First();



                
            }
        }
    }
}
