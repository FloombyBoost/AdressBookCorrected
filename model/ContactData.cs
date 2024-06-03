using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdressBook_web_test
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData()
        {
           
        }

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
        private string allInfo;

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
        public string AllInfo 
        { get
            {
                return (Name +" "+ LastName + "\r\n" + matchAdress(Address) + matchAll(AllPhonesAllInfo) +
                  matchAll(AllEmails)).Trim();
            }
            set { allInfo = value; } 

        }





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



        public string AllPhonesAllInfo
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (ReplacePhone(HomePhone) + ReplacePhone(MobilePhone) + ReplacePhone(WorkPhone)).Trim();
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
                    return (matchEmail(Email1) + matchEmail(Email2) + matchEmail(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }


        private string matchEmail(string email)// новый
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        private string matchAdress(string data)// новый
        {
            if (data == null || data == "")
            {
                return "\r\n";
            }
            return data + "\r\n\r\n";
        }
        private string matchAll(string data)// новый
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n\r\n";
        }

        private string ReplacePhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            if (phone == HomePhone) { return "H: "+ phone + "\r\n"; }
            if (phone == MobilePhone) { return "M: " + phone + "\r\n"; }
            return "W: " + phone + "\r\n"; 

            
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        

    }
}
