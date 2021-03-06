﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAppLib;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class PersonTreeViewModel : ViewModelBase{
		private GRDBCont db;

		public PersonTreeViewModel() {
			RootPair = new PersonPairNode() {
				X = 50,
				Y = 100,
				Male = new GRAppLib.DB.Person() {
					FirstName_ = "Alpha",
					BirthDate = DateTime.Now,
					Father = new Person() {
						FirstName_ = "AlphaF"
					},
					Mother = new Person() {
						FirstName_ = "AlphaM"
					}
				},
				Female = new GRAppLib.DB.Person() { FirstName_ = "Beta", BirthDate = DateTime.Now}
			};
			Pairs.Add(RootPair);
			RootPair.ExpandBranch.Execute(null);
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
			RootPair.ExpandBranch.Execute(null);
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
			pp.ExpandBranch = new UVMCommand(par => {
				if (pp.Male != null) {
					pp.MaleParentsPair = new PersonPairNode() {
						X = pp.X + 200,
						Y = pp.Y - 100,
						Male = pp.Male.Father,
						Female = pp.Male.Mother
					};
					Pairs.Add(pp.MaleParentsPair);
					InitPair(pp.MaleParentsPair);
				} else {
					var person = CreatePersonDialogAsync(0);
					pp.Male = (Person)person;
				}
				if (pp.Female != null) {
					pp.FemaleParentsPair = new PersonPairNode() {
						X = pp.X + 200,
						Y = pp.Y + 100,
						Male = pp.Female.Father,
						Female = pp.Female.Mother
					};
					pairs.Add(pp.FemaleParentsPair);
					InitPair(pp.FemaleParentsPair);
				}
				RaisePropertyChanged("Pairs");
			});
		}

		private object CreatePersonDialogAsync(Gender gender) {
			var tdb = new GRDBCont(MainViewModel.CurrentConnectionDBLocation);
			Person person = new Person();
			person.Gender_ = gender;
			person.GenderLocked = true;
			person.SetNull(new UVMCommand(p => {
				OpenWindowWithObject("CreatePersonSimpleEditor", "MainWindow_", r => {
					if (r == System.Windows.Forms.DialogResult.OK) {
						tdb.Persons.Add(person);
						tdb.SaveChanges();
						MainViewModel.RequestUpdate(UpdateTarget.Persons);
					}
				}, person, null);
			}, p => person.IsNull));
			return person;
		}

		private List<PersonPairNode> pairs = new List<PersonPairNode>();
		public List<PersonPairNode> Pairs { get { return pairs; } set { pairs = value; RaisePropertyChanged("Pairs"); } }
	}
}
