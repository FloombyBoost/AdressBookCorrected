using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using MySqlX.XDevAPI.Relational;
using static LinqToDB.Sql;

namespace AdressBook_web_test
{
	[Table(Name = "group_list")]
	public class GroupData : IEquatable<GroupData>, IComparable<GroupData>// его можно сравнивать с другими обьектами <GroupData>
	{
		public GroupData() // бызовый конструктор с 1 главным параметром Имя
		{

		}
		public GroupData(string name) // бызовый конструктор с 1 главным параметром Имя 
		{
			Name = name;
		}
		public bool Equals(GroupData other)
		{
			if (Object.ReferenceEquals(other, null)) return false;
			if (Object.ReferenceEquals(this, other)) return true;
			return Name == other.Name;
		}
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
		public override string ToString()
		{
			return "name=" + Name + "\nheader = " + Header + "\nfooter = " + Footer;
		}
		public int CompareTo(GroupData other)
		{
			if (Object.ReferenceEquals(other, null)) { return 1; }

			return Name.CompareTo(other.Name);

		}


		public GroupData(string name, string header, string footer) // конструктор сразу для 3-х параметров
		{
			Name = name;
			Header = header;
			Footer = footer;
		}

		// private string name; // главный параметр
		[Column(Name = "group_name")]
		public string Name { get; set; }
		//{
		//get { return name; }
		//set { name = value; }
		//}

		//private string header = "";// делаем поле вспомогательным
		[Column(Name = "group_header")]
		public string Header { get; set; }
		/*
		{
			get { return header; }
			set { header = value; }
		}
		*/

		//private string footer = "";// делаем поле вспомогательным
		[Column(Name = "group_footer")]

		public string Footer { get; set; }
		/*
		{
			get { return footer; }
			set { footer = value; }
		}
		*/
		[Column(Name = "group_id"), PrimaryKey, Identity]
		public string Id { get; set; }

		public static List<GroupData> GetAll()
		{
			using (AddressBookDB db = new AddressBookDB())
			{
				return (from g in db.Groups select g).ToList();
			}

		}

		public List<ContactData> GetContacts ()
		{

            using (AddressBookDB db = new AddressBookDB())
			{
				return (from c in db.Contacts
						from gcr in db.GCR.Where(p => p.GroupID == Id && p.ContactID == c.Id) select c  ).Distinct().ToList();



			}

		}
	}
}
