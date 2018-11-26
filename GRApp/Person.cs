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
					.Persons
					.Where(p => p.Mother.Id == this.Id || p.Father.Id == Id).ToList();
			}
		}
	}
}
