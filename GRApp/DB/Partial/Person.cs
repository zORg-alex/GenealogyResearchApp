using GenealogyResearchApp.GRAppLib.DB;
using GRAppLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.GRAppLib.DB {
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
		public virtual Name FirstName_ { get { return FirstName; } set { FirstName = value; FirstnameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("FirstnameRaw"); } }
		public virtual Name LastName_ { get { return LastName; } set { LastName = value; LastnameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("LastnameRaw"); } }
		public virtual Name MiddleName_ { get { return MiddleName; } set { MiddleName = value; MiddlenameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("MiddlenameRaw"); } }


		private bool isNull;
		public bool IsNull { get { return isNull; } set { isNull = value; RaisePropertyChanged("IsNull"); } }

		public bool GenderLocked { get; set; }

		public UVMCommand CreatePerson;

		public void SetNull(UVMCommand CreatePersonCommand) {
			isNull = true;
			CreatePerson = CreatePersonCommand;
		}

		public Gender Gender_ { get { return Gender.HasValue ? (Gender)Gender.Value : (Gender)(int?)-1; } set { Gender = (byte)value; } }
	}
}
