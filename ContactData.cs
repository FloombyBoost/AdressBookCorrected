using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{
    public class ContactData
    {

		public ContactData(string name, string LastName) 
		{
			this.Name = name;
			this.LastName = LastName;
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


	}
}
