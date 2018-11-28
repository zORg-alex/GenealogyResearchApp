using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.ViewModel {
    public class MainViewModel : Notifiable, IDialogHelper {

        Func<string, string, string, string> _openDialog = (type, filter, path) => { return ""; };
        public Func<string, string, string, string> OpenDialog { get { return _openDialog; } set { _openDialog = value; } }

		GRDBCont db;

		public MainViewModel() {
			db = new GRDBCont();
			Persons = db.Persons.ToList();
			Places = db.Places.ToList();

			Views.Add(new PersonViewModel());
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
