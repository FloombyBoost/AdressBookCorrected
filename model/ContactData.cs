using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string name, string LastName)
        {
            this.Name = name;
            this.LastName = LastName;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return (Name == other.Name) && (LastName == other.LastName);
        }
        public override int GetHashCode()
        {
            return (LastName.GetHashCode());
        }

        public override string ToString()
        {
            return "name=" + Name + "Lastname=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            if (Name == other.Name)
            {
                return (LastName.CompareTo(other.lastname));
            }
            return (Name.CompareTo(other.Name));

        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastname;
        private string allPhones;
        private string allEmails;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        
        public string AllPhones 
        {
            get 
            {
                if (allPhones != null) 
                { 
                    return allPhones; 
                }
                else 
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }

       
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email1 + "\r\n" + Email2 + "\r\n" + Email3 + "\r\n").Trim();
                }
            }
            set { allEmails = value; }
        }
       
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        

    }
}
