using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zLib;
using GenealogyResearchApp.GRAppLib.DB;

namespace GenealogyResearchApp.ViewModel {
    public class MainViewModel : ViewModelBase, IDialogHelper {

        Func<string, string, string, string> _openDialog = (type, filter, path) => { return ""; };
		public Func<string, string, string, string> OpenDialog { get { return ViewModelBase._openDialog; } set { ViewModelBase._openDialog = value; } }
		public Action<string, string, Action<DialogResult>, string, string, Func<object, bool>> OpenWindow { get { return ViewModelBase._openWindow; } set { ViewModelBase._openWindow = value; } }
		public Action<string, object, string, Action<DialogResult>, Action<object>, string, string, Func<object, bool>> OpenWindowWithReturn { get { return ViewModelBase._openWindowWithReturn; } set { ViewModelBase._openWindowWithReturn = value; } }

		GRDBCont db;

		public MainViewModel() {
			//Persons = new List<Person>();
			//Places = new List<Place>();
			View.RequestUpdate = t => {
				Views.ForEach(v => v.Update(t));
			};
			Views.Add(new TestPersonViewModel());
			SelectedView = Views.FirstOrDefault();
		}

		public MainViewModel(bool execute) {
			db = new GRDBCont();
			Persons = db.Persons.ToList();
			Places = db.Places.ToList();

			View.RequestUpdate = t => {
				Views.ForEach(v => v.Update(t));
			};
			Views.Add(new PersonViewModel());
			SelectedView = Views.FirstOrDefault();
		}

		public void Save() {
			db.SaveChanges();
		}

		private View selectedview;
		public View SelectedView {
			get {
				if (selectedview == null) selectedview = Views.FirstOrDefault();
				return selectedview; }
			set { selectedview = value; RaisePropertyChanged("SelectedView"); }
		}

		private List<View> views = new List<View>();
		public List<View> Views {
			get { return views; }
			set { views = value; RaisePropertyChanged("Views"); }
		}
		
		private List<Person> persons;
		public List<Person> Persons {
			get { return persons; }
			set { persons = value; RaisePropertyChanged("Persons"); }
		}

		private List<Place> places;

		public List<Place> Places {
			get { return places; }
			set { places = value; RaisePropertyChanged("Places"); }
		}

	}
}
