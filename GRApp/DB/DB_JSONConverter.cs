using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.GRAppLib.DB {
	public class DB_JSONConverter : CustomCreationConverter<Name> {
		public override Name Create(Type objectType) {
			return new Name_();
		}
	}
}
