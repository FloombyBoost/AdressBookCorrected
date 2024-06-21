using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdressBook_web_test
{
    public class RemoveContactsGromGroup : AuthTestBase
    {

        [Test]

        public void RemoveContactFromGroup()
        {


            List<GroupData> groupListData = GroupData.GetAll();
            List <ContactData> contacttList = ContactData.GetAll();

            app.Auth.AutoenerateGroupContact(groupListData, contacttList);

            if (groupListData.Count == 0) 
            {
                GroupData group = new GroupData("GroupAuto"+ GenerateRandomString(3));
                group.Header = "";
                group.Footer = "";
                app.Group.Create(group);
            }
            if (contacttList.Count == 0)
            {
                ContactData contact = new ContactData("FirstName"+ GenerateRandomString(2), "LastName"+ GenerateRandomString(3));
               app.Contact.Create(contact);
            }

            for (int i = 0; i < groupListData.Count; i++)
            {
                GroupData group = groupListData[i];
                //GroupData group = GroupData.GetAll()[0];//  group  это 0  группа из всех групп - GetAll взял список всех групп
                List<ContactData> ContactsInGroupOldList = group.GetContacts();  //Берет все контакты которые есть в таблице .GCR  и которые привязаны к найденной  0 группе. т.е все контакты которые есть в 0 группе
                if (ContactsInGroupOldList.Count <= 0 && i < groupListData.Count - 1) continue;
                else 
                {
                    try 
                    {
                        ContactData contactToAddForRemove = ContactData.GetAll().First();
                        app.Contact.AddcontactToGroup(contactToAddForRemove, group);
                    }
                    catch
                    {
                        ContactData Newcontact = new ContactData("NameTest", "AutoCreate{LastName}ContactForAdding");
                        app.Contact.Create(Newcontact);
                        ContactData contactToAddForRemove = ContactData.GetAll().First();
                        app.Contact.AddcontactToGroup(contactToAddForRemove, group);
                       ContactsInGroupOldList = group.GetContacts();  
                    }
                }
                

                ContactData ContactForRemove = ContactsInGroupOldList.First();
                //if (ContactForRemove == null) continue;

                app.Contact.RemoveContactFromGroup(ContactForRemove, group);// удаляем контакт из группы


                //Actions

                List<ContactData> ContactsInGroupNewList = group.GetContacts();  //повторно взять контакты из этой группы и сохранить.
                                                                                 //сравнить ContactsInGroup




                ContactsInGroupNewList.Add(ContactForRemove);
                ContactsInGroupNewList.Sort();
                ContactsInGroupOldList.Sort();
                ClassicAssert.AreEqual(ContactsInGroupOldList, ContactsInGroupNewList);
                if (ContactForRemove != null) break;
            }

            }
    }
}
