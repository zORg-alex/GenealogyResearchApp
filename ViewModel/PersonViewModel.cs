using GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.ViewModel {
	public class PersonViewModel : View {

		GRDBCont db;

		public PersonViewModel() {
			db = new GRDBCont();
			Persons = db.Persons.ToList();
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

		
	}
}
