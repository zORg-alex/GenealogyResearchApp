using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.GRAppLib.DB {
	public class Name_ : Name{
		public override NameGroup NameGroup { get { return base.NameGroup; } set { base.NameGroup = value; RaisePropertyChanged("NameGroup"); } }
	}

	public partial class Name : Notifiable { }

}
