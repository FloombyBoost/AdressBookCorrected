using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_web_test
{

	    internal class GroupData
    {
		public GroupData(string name) // бызовый конструктор с 1 главным параметром Имя
		{
			this.Name = name;
		}
		


		public GroupData (string name,string header, string footer) // конструктор сразу для 3-х параметров
		{
			this.Name = name;
			this.Header = header;
			this.Footer = footer;
		}

        private string name; // главный параметр
        public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string header = "";// делаем поле вспомогательным

		public string Header
		{
			get { return header; }
			set { header = value; }
		}

		private string footer = "";// делаем поле вспомогательным

        public string Footer
		{
			get { return footer; }
			set { footer = value; }
		}


	}
}
