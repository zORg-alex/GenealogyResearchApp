using GenealogyResearchApp.GRAppLib.DB;
using GenealogyResearchApp.GRAppLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class PersonViewModel : View {

		GRDBCont db;

		public PersonViewModel() {
			db = new GRDBCont();
			Persons = db.Persons.OrderBy(p=>p.FirstnameRaw).ToList();
			SelectedPerson = persons.FirstOrDefault();
			NewPerson = new UVMCommand(p=> {
				Person P = new Person() { FirstnameRaw = "", MiddlenameRaw = "", LastnameRaw = ""};
				db.Persons.Add(P);
				SelectedPerson = P;
				db.SaveChanges();
				RequestUpdate(DBTypes.Person);
			});
		}
		
		public override void Update(DBTypes target) {
			switch (target) {
				case DBTypes.Person:
					Persons = db.Persons.OrderBy(p => p.FirstnameRaw).ToList();
					break;
				case DBTypes.Name:
					SelectedPerson = SelectedPerson;
					break;
				case DBTypes.NameGroup:
					SelectedPerson = SelectedPerson;
					break;
				case DBTypes.Event:
					SelectedPerson = SelectedPerson;
					break;
				case DBTypes.Place:
					break;
			}
		}

		private List<Person> persons;
		public List<Person> Persons {
			get { return persons; }
			set { persons = value; RaisePropertyChanged("Persons"); }
		}

		private Person selectedPerson;
		public Person SelectedPerson {
			get { return selectedPerson; }
			set {
				if (SelectedPerson != value) {
					selectedPerson = value;
					FirstNameModel = new NameViewModel(db, SelectedPerson.FirstName, n => { SelectedPerson.FirstName_ = n; db.SaveChanges(); });
					MiddleNameModel = new NameViewModel(db, SelectedPerson.MiddleName, n => { SelectedPerson.MiddleName_ = n; db.SaveChanges(); });
					LastNameModel = new NameViewModel(db, SelectedPerson.LastName, n => { SelectedPerson.LastName_ = n; db.SaveChanges(); });
					RaisePropertyChanged("SelectedPerson");
				}
			}
		}

		private NameViewModel firstNameModel;
		public NameViewModel FirstNameModel { get { return firstNameModel; } set { firstNameModel = value; RaisePropertyChanged("FirstNameModel"); } }

		private NameViewModel middleNameModel;
		public NameViewModel MiddleNameModel { get { return middleNameModel; } set { middleNameModel = value; RaisePropertyChanged("MiddleNameModel"); } }

		private NameViewModel lastNameModel;
		public NameViewModel LastNameModel { get { return lastNameModel; } set { lastNameModel = value; RaisePropertyChanged("LastNameModel"); } }
		
		public UVMCommand NewPerson { get; private set; }
	}
}
