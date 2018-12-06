using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAppLib;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class PersonTreeViewModel : View{
		private GRDBCont db;

		public PersonTreeViewModel() {
			RootPair = new PersonPairNode() {
				X = 50,
				Y = 100,
				Male = new GRAppLib.DB.Person() { FirstName_ = "Alpha", BirthDate = DateTime.Now},
				Female = new GRAppLib.DB.Person() { FirstName_ = "Beta", BirthDate = DateTime.Now}
			};
		}

		public PersonTreeViewModel(GRDBCont DB) {
			db = DB;
			var l = db.Persons.ToList();
			var r = db.Persons.FirstOrDefault(p => p.Father != null && p.Mother != null);
			RootPair = new PersonPairNode() {
				X = 50,
				Y = 100,
				Male = (r.Gender == 0) ? r : null,
				Female = (r.Gender == 1) ? r : null
			};
		}
		
		private PersonPairNode rootPair;

		public PersonPairNode RootPair { get { return rootPair; } set {
				Pairs.Clear();
				rootPair = value;
				Pairs.Add(RootPair);
				InitPair(RootPair);
				RaisePropertyChanged("RootPair");
			}
		}
		
		void InitPair(PersonPairNode pp) {
			pp.ExpandBranch = new UVMCommand(p => {
				if (pp.Male != null) {
					pp.MaleParentsPair = new PersonPairNode() {
						X = pp.X + 200,
						Y = pp.Y - 50,
						Male = pp.Male.Father,
						Female = pp.Male.Mother
					};
					Pairs.Add(pp.MaleParentsPair);
					InitPair(pp.MaleParentsPair);
				}
				if (pp.Female != null) {
					pp.FemaleParentsPair = new PersonPairNode() {
						X = pp.X + 200,
						Y = pp.Y + 50,
						Male = pp.Female.Father,
						Female = pp.Female.Mother
					};
					pairs.Add(pp.FemaleParentsPair);
					InitPair(pp.FemaleParentsPair);
				}
			});
		}

		private List<PersonPairNode> pairs = new List<PersonPairNode>();
		public List<PersonPairNode> Pairs { get { return pairs; } set { pairs = value; RaisePropertyChanged("Pairs"); } }
	}
}
