using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{
    public class ContactData:IEquatable<ContactData>,IComparable<ContactData>
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
            return (Name == other.Name) && (LastName== other.LastName);
        }
        public override int GetHashCode()
        {
            return (LastName.GetHashCode());
        }

        public override string ToString()
        {
            return "name="+ Name + "Lastname=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            if (Name == other.Name)
            {
                return (LastName.CompareTo(other.lastname)); 
            }
            return (Name.CompareTo(other.Name)) ;

        }
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string lastname;

		public string LastName
		{
			get { return lastname; }
			set { lastname = value; }
		}

        public string Id { get; set; }

    }
}
