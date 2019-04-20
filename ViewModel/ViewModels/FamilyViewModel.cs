using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.ViewModel {
	public class FamilyViewModel : ViewModelBase {
		public FamilyViewModel() {

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
					RaisePropertyChanged("SelectedPerson");
				}
			}
		}

	}
}
