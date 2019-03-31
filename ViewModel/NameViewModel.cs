using GenealogyResearchApp.GRAppLib;
using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class NameViewModel : View {
		public NameViewModel() { }
		public NameViewModel(Name Name, Action<Name> NameChangedCallback) {
			this.Name = Name;
			RawName = (Name != null) ? Name.NameRaw : "";
			this.NameChangedCallback = NameChangedCallback;
			NewName = new UVMCommand(p => {
				//Don't do that!
				//NameGroup g = new NameGroup() { PrimeName = RawName};
				Name n = new Name() { NameRaw = RawName };
				//db.NameGroups.Add(g);
				db.Names.Add(n);
				db.SaveChanges();
				this.Name = n;
				RequestUpdate(DBTypes.Name);
			}, p => this.RawName != null || this.RawName != "");
			NewNameGroup = new UVMCommand(p => {
				NameGroup g = new NameGroup() { PrimeName = NameGroupFilter == "" ? this.Name.NameRaw : NameGroupFilter };
				db.NameGroups.Add(g);
				db.SaveChanges();
				this.Name.NameGroup = g;
				RequestUpdate(DBTypes.NameGroup);
				NameGroupFilter = NameGroupFilter;
			}, p => this.Name != null);
			if (Name != null) selectedNameGroup = Name.NameGroup;
			NameGroupFilter = "";
		}

		public override void Update(DBTypes target) {
			switch (target) {
				case DBTypes.Person:
					break;
				case DBTypes.Name:
					SimilarNames = db.Names.Where(n => n.NameRaw.Contains(RawName)).ToList();
					break;
				case DBTypes.NameGroup:
					NameGroupFilter = NameGroupFilter;
					break;
				case DBTypes.Event:
					break;
				case DBTypes.Place:
					break;
				default:
					break;
			}
		}

		private string rawName;
		/// <summary>
		/// Should be changing with every typed letter for live search
		/// </summary>
		public string RawName {
			get { return rawName; }
			set {
				SimilarNames = db.Names.Where(n => n.NameRaw.Contains(value)).ToList();
				if (rawName == value) return;
				rawName = value;

				//If there is one exact, assign it immediately
				var fn = db.Names.FirstOrDefault(n => n.NameRaw == RawName);
				if (fn != null && Name != fn) {
					Name = fn;
					NameChangedCallback(name);
				}
				if (RawName == "") {
					Name = null;
					NameChangedCallback(name);
				}

				RaisePropertyChanged("RawName");
			}
		}

		private Name name;
		public Name Name {
			get { return name; }
			set {
				if (name != value) {
					name = value;
					if (name != null) {
						RawName = name.NameRaw;
						NameGroupFilter = "";
						SelectedNameGroup = Name.NameGroup;
					}
					if (name == null)
						RawName = "";
					NameChangedCallback(name);
				}

				RaisePropertyChanged("Name");
			}
		}

		Action<Name> NameChangedCallback = s => { };

		private List<Name> similarNames;
		public List<Name> SimilarNames { get { return similarNames; } set { similarNames = value; RaisePropertyChanged("SimilarNames"); } }

		public UVMCommand NewName { get; private set; }
		public UVMCommand NewNameGroup { get; private set; }

		private List<NameGroup> filteredNameGroups;
		public List<NameGroup> FilteredNameGroups { get { return filteredNameGroups; } set { filteredNameGroups = value; RaisePropertyChanged("FilteredNameGroups"); } }

		private NameGroup selectedNameGroup;
		public NameGroup SelectedNameGroup { get { return selectedNameGroup; } set { selectedNameGroup = value;
				if (this.Name.NameGroup != value) {
					this.Name.NameGroup = value;
					NameChangedCallback(this.Name);
				}
				RaisePropertyChanged("SelectedNameGroup"); } }

		private string nameGroupFilter;
		public string NameGroupFilter {
			get { return nameGroupFilter; }
			set {
				nameGroupFilter = value;
				List<NameGroup> l = new List<NameGroup>();
				if (NameGroupFilter == "") {
					l.AddRange(db.NameGroups);
				} else {
					if (Name != null && Name.NameGroup != null) l.Add(Name.NameGroup);
					l.AddRange(db.NameGroups.Where(g => g.PrimeName.Contains(NameGroupFilter)));
				}
				FilteredNameGroups = l;
				RaisePropertyChanged("NameGroupFilter");
			}
		}


		//public class NameLinkableTo {
		//	public int Id { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.Id;
		//		} }
		//	public int NameGroupId { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.NameGroupId;
		//		} }
		//	public string NameRaw { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.NameRaw;
		//		} }
		//	public NameGroup NameGroup { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.NameGroup;
		//		} }
		//	public ICollection<Person> PersonsWithNames { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.PersonsWithNames;
		//		} }
		//	public ICollection<Person> PersonsWithMiddleNames { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.PersonsWithMiddleNames;
		//		} }
		//	public ICollection<Person> PersonsWithLastNames { get {
		//			if (OriginalName == null) throw new ArgumentNullException();
		//			return OriginalName.PersonsWithLastNames;
		//		} }

		//	public UVMCommand LinkToThis { get; set; }

		//	private NameViewModel nameModel;
		//	internal NameViewModel NameModel { set { nameModel = value; } }

		//	public Name OriginalName { get; set; }
		//}
	}
}
