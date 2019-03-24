using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.ViewModel {
	public class NameLinkingViewModel : View {
		public NameLinkingViewModel() {
			NameGroups = db.NameGroups.ToList();
			Filter = "";
		}

		private Name selectedName;
		public Name SelectedName { get { return selectedName; } set { selectedName = value; RaisePropertyChanged("SelectedName"); } }

		//private List<Name> names;
		//public List<Name> Names { get { return names; } set { names = value; RaisePropertyChanged("Names"); } }

		private List<Name> filteredNames;
		public List<Name> FilteredNames { get { return filteredNames; } set { filteredNames = value; RaisePropertyChanged("FilteredNames"); } }

		private string filter;
		public string Filter {
			get { return filter; }
			set {
				if (filter == value) return;
				filter = value;
				if (ShowUnlinked) {
					FilteredNames = db.Names.Where(n => n.NameGroupId == null && n.NameRaw.Contains(filter)).ToList();
				} else if (filter == "") FilteredNames = db.Names.ToList();
				else FilteredNames = db.Names.Where(n => n.NameRaw.Contains(filter)).ToList();
				RaisePropertyChanged("Filter");
			}
		}

		private bool showUnlinked;
		public bool ShowUnlinked {
			get { return showUnlinked; }
			set {
				showUnlinked = value;
				if (showUnlinked) Filter = "";
				RaisePropertyChanged("ShowUnlinked");
			}
		}

		private List<NameGroup> nameGroups;
		public List<NameGroup> NameGroups { get { return nameGroups; } set { nameGroups = value; RaisePropertyChanged("NameGroups"); } }

	}
}
