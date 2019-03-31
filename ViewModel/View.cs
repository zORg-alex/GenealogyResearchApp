using GenealogyResearchApp.GRAppLib;
using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class View : Notifiable {
		private string type;
		public string Type {
			get {
				if (type == null) type = GetType().Name;
				return type;
			}
			set { type = value; RaisePropertyChanged("Type");
			}
		}

		private float leftPaneWidth;
		public float LeftPaneWidth {
			get { return leftPaneWidth; }
			set {
				if (leftPaneWidth != value) {
					leftPaneWidth = value;
					MainViewModel.Instance.LeftPaneWidth = value;
				}
			}
		}

		internal static zContext db = new zContext();
		
		public virtual void Update(DBTypes target) { }
		public static Action<DBTypes> RequestUpdate = target => { };
	}
}
