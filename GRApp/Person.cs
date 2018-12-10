using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GRAppLib.DB {
	public partial class Person : Notifiable {
		public List<Person> Children {
			get {
				return new GRDBCont()
					.Persons.AsNoTracking()
					.Where(p => p.Mother.Id == this.Id || p.Father.Id == Id).ToList();
			}
		}

		private Person spouse;
		private bool spouseIsNull;
		public Person Spouse { get {
				if (spouseIsNull) return null;

				Event evt = Events.FirstOrDefault(e => e.Type == "Marriage");
				if (evt != null) spouse = evt.Attendees.FirstOrDefault();
				evt = EventsAttended.FirstOrDefault(e => e.Type == "Marriage" && e.Attendees.FirstOrDefault().Id == Id);
				if (evt != null) spouse = evt.Person;
				else spouseIsNull = true;

				return spouse;
			}
		}
		//TODO replace with creating grouped names
		public string FirstName_ { get { return FirstnameRaw; } set { FirstnameRaw = value; } }
		public string MiddleName_ { get { return MiddlenameRaw; } set { MiddlenameRaw = value; } }
		public string LastName_ { get { return LastnameRaw; } set { LastnameRaw = value; } }


		private bool isNull;
		public bool IsNull { get { return isNull; } set { isNull = value; RaisePropertyChanged("IsNull"); } }

		public UVMCommand CreatePerson;
	}
}
