using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenealogyResearchApp.GRAppLib;

namespace GenealogyResearchApp.ViewModel {
	public class NameLinkingViewModel : ViewModelBase {
		public NameLinkingViewModel() {
			NameGroups = db.NameGroups.ToList();
			Filter = "";
		}
		public override void Update(DBTypes target) {
			switch (target) {
				case DBTypes.Person:
					break;
				case DBTypes.Name:
					Filter = filter;
					break;
				case DBTypes.NameGroup:
					NameGroups = db.NameGroups.ToList();
					break;
				case DBTypes.Event:
					break;
				case DBTypes.Place:
					break;
				default:
					break;
			}
		}

		private Name selectedName;
		public Name SelectedName { get { return selectedName; } set { selectedName = value; RaisePropertyChanged("SelectedName"); } }

		private List<Name> filteredNames;
		public List<Name> FilteredNames { get { return filteredNames; } set { filteredNames = value; RaisePropertyChanged("FilteredNames"); } }

		private string filter;
		public string Filter {
			get { return filter; }
			set {
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
