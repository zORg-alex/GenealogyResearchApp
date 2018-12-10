using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.ViewModel {
    public class MainViewModel : ViewModelBase {

		string ConnectionStringBase = "metadata=res://*/DB.GRDB.csdl|res://*/DB.GRDB.ssdl|res://*/DB.GRDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename={0};integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework&quot;";
		string DefaultDBLocation = "|DataDirectory|\\DB\\GenealogyResearchAppDB.mdf";
		string AlternativeDBLocation = "C:\\Users\\AUljanovs\\Documents\\GRDB\\GenealogyResearchAppDB.mdf";
		GRDBCont db;

		public MainViewModel() {
			Persons = new List<Person>();
			Places = new List<Place>();

			Views.Add(new TestPersonViewModel());
			SelectedView = Views.FirstOrDefault();
		}

		public MainViewModel(bool execute) {
			db = new GRDBCont(AlternativeDBLocation);
			Persons = db.Persons.ToList();
			Places = db.Places.ToList();

			Views.Add(new PersonTreeViewModel(db));
			SelectedView = Views.FirstOrDefault();
		}

		private ViewModelBase selectedview;
		public ViewModelBase SelectedView {
			get {
				if (selectedview == null) selectedview = Views.FirstOrDefault();
				return selectedview; }
			set { selectedview = value; RaisePropertyChanged("SelectedView"); }
		}

		public void Save() {
			if (db != null) db.SaveChanges();
		}

		private List<ViewModelBase> views = new List<ViewModelBase>();
		public List<ViewModelBase> Views {
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
