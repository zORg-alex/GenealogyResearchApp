using GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.ViewModel {
	public class PersonViewModel : ViewModelBase {

		GRDBCont db;
		public PersonViewModel() { }
		public PersonViewModel(GRDBCont DB) {
			db = DB;
			Persons = db.Persons.ToList();
			Places = db.Places.ToList();
			SelectedPerson = persons.FirstOrDefault();
		}

		private List<Person> persons;
		public List<Person> Persons {
			get { return persons; }
			set { persons = value; RaisePropertyChanged("Persons"); }
		}

		private Person selectedPerson;
		public Person SelectedPerson {
			get { return selectedPerson; }
			set { selectedPerson = value; RaisePropertyChanged("SelectedPerson"); }
		}

		private List<Place> places;
		public List<Place> Places { get { return places; } set { places = value; RaisePropertyChanged("Places"); } }
		
	}
}
