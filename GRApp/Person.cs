using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAppLib.DB {
	public partial class Person {
		public List<Person> Children {
			get {
				return new GRDBCont()
					.Persons.AsNoTracking()
					.Where(p => p.Mother.Id == this.Id || p.Father.Id == Id).ToList();
			}
		}

		//TODO replace with creating grouped names
		public string FirstName_ { get { return FirstnameRaw; } set { FirstnameRaw = value; } }
		public string MiddleName_ { get { return MiddlenameRaw; } set { MiddlenameRaw = value; } }
		public string LastName_ { get { return LastnameRaw; } set { LastnameRaw = value; } }


	}
}
