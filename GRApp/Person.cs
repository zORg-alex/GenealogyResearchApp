using GenealogyResearchApp.GRAppLib.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.GRAppLib.DB {
	public partial class Person : Notifiable {
		public List<Person> Children {
			get {
				return new GRDBCont()
					.Persons.AsNoTracking()
					.Where(p => p.Mother.Id == this.Id || p.Father.Id == Id).ToList();
			}
		}
		
		public virtual Name FirstName_ { get { return FirstName; } set { FirstName = value; FirstnameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("FirstnameRaw"); } }
		public virtual Name LastName_ { get { return LastName; } set { LastName = value; LastnameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("LastnameRaw"); } }
		public virtual Name MiddleName_ { get { return MiddleName; } set { MiddleName = value; MiddlenameRaw = (value != null) ? value.NameRaw : ""; RaisePropertyChanged("MiddlenameRaw"); } }
	}
}
