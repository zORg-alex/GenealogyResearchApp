using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.ViewModel {
	public class TestPersonViewModel : PersonViewModel {
		public TestPersonViewModel() {
			Persons = new List<GRAppLib.DB.Person>() {
				new GRAppLib.DB.Person() {
					FirstName = new Name() { NameRaw = "Name"},
					MiddleName = new Name() { NameRaw = "MiddleName" },
					LastName = new Name() { NameRaw = "Surname" },
					BirthDate = new DateTime(1898, 1, 25),
					DeathDate = new DateTime(1965, 5, 27)
				},
				new GRAppLib.DB.Person() {
					FirstName = new Name() { NameRaw = "Second" }, MiddleName = new Name() { NameRaw = "M" }, LastName = new Name() { NameRaw = "One" }
				}
			};
			SelectedPerson = Persons.FirstOrDefault();
		}
	}
}
