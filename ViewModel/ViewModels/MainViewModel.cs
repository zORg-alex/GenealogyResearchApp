using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zLib;
using GenealogyResearchApp.GRAppLib.DB;

namespace GenealogyResearchApp.ViewModel {
    public class MainViewModel : Notifiable {
		
		public Func<string, string, string, string> OpenDialog { get { return ViewModelBase._openDialog; } set { ViewModelBase._openDialog = value; } }
		public Action<string, string, Action<DialogResult>, string, string, Func<object, bool>> OpenWindow { get { return ViewModelBase._openWindow; } set { ViewModelBase._openWindow = value; } }
		public Action<string, object, string, Action<DialogResult>, Action<object>, string, string, Func<object, bool>> OpenWindowWithReturn { get { return ViewModelBase._openWindowWithReturn; } set { ViewModelBase._openWindowWithReturn = value; } }
		public Action<string, string, Action<DialogResult>, object, Func<object, bool>> OpenWindowWithObject { get { throw new NotImplementedException(); }	set { throw new NotImplementedException(); } }

		zContext db;

		public MainViewModel() {
			instance = this;
			//Persons = new List<Person>();
			//Places = new List<Place>();
			ViewModelBase.RequestUpdate = t => {
				Views.ForEach(v => v.Update(t));
			};
			Views.Add(new TestPersonViewModel());
			SelectedView = Views.FirstOrDefault();
		}

		public MainViewModel(bool execute) {
			instance = this;
			db = zContext.Deserialize(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\GRApp\\default-db.json");
			ViewModelBase.db = db;
			ViewModelBase.RequestUpdate = t => {
				Views.ForEach(v => v.Update(t));
			};
			Views.Add(new PersonViewModel());
			Views.Add(new NameLinkingViewModel());
			Views.Add(new FamilyViewModel());
			SelectedView = Views.FirstOrDefault();
		}

		public void Save() {
			zContext.Serialize(db);
		}

		private ViewModelBase selectedview;
		public ViewModelBase SelectedView {
			get {
				if (selectedview == null) selectedview = Views.FirstOrDefault();
				return selectedview; }
			set {
				selectedview = value;
				if (value != null) lastView = value.Type;
				RaisePropertyChanged("SelectedView");
			}
		}

		private List<ViewModelBase> views = new List<ViewModelBase>();
		public List<ViewModelBase> Views {
			get { return views; }
			set { views = value; RaisePropertyChanged("Views"); }
		}
		
		//private List<Person> persons;
		//public List<Person> Persons {
		//	get { return persons; }
		//	set { persons = value; RaisePropertyChanged("Persons"); }
		//}

		//private List<Place> places;

		//public List<Place> Places {
		//	get { return places; }
		//	set { places = value; RaisePropertyChanged("Places"); }
		//}

		private string lastView;
		public string LastView { get { return lastView; }
			set {
				lastView = value;
				SelectedView = Views.FirstOrDefault(v => v.Type == lastView);
			}
		}

		private float leftPaneWidth;
		public float LeftPaneWidth {
			get { return leftPaneWidth; }
			set {
				if (leftPaneWidth != value) {
					leftPaneWidth = value;
					SelectedView.LeftPaneWidth = value;
				}
				RaisePropertyChanged("LeftPaneWidth");
			}
		}

		public static MainViewModel instance;
		public static MainViewModel Instance { get { return instance; } }

	}
}
