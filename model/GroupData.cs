using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{

	    public class GroupData: IEquatable<GroupData>,IComparable<GroupData>// его можно сравнивать с другими обьектами <GroupData>
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
			if (Object.ReferenceEquals(other,null)) return false;
			if (Object.ReferenceEquals(this, other)) return true;
			return Name == other.Name;
		}
		public override int GetHashCode() 
		{
			return Name.GetHashCode();
		}
		public override string ToString()
		{
			return "name=" + Name + "\nheader = " + Header + "\nfooter = " + Footer  ; 
		}
		public   int CompareTo(GroupData other)
		{
			if (Object.ReferenceEquals(other,null)) { return 1; }

			return Name.CompareTo(other.Name);

		}


		public GroupData (string name,string header, string footer) // конструктор сразу для 3-х параметров
		{
			Name = name;
			Header = header;
			Footer = footer;
		}

		// private string name; // главный параметр
		public string Name { get; set; }
		//{
			//get { return name; }
			//set { name = value; }
		//}

		//private string header = "";// делаем поле вспомогательным

		public string Header { get; set; }
		/*
		{
			get { return header; }
			set { header = value; }
		}
		*/

		//private string footer = "";// делаем поле вспомогательным

        public string Footer { get; set; }
		/*
		{
			get { return footer; }
			set { footer = value; }
		}
		*/
		public string Id { get; set; }


	}
}
