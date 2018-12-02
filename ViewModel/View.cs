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
			set { type = value; RaisePropertyChanged("Type"); } }

	}
}
