using System;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;

namespace GRAppLib {
	public class ConnectionString {
		private ConnectionString() { }

		public static string Connect() {
			return Connect("|DataDirectory|\\DB\\GenealogyResearchAppDB.mdf");
		}
		public static string Connect(string FilePath) {
			EntityConnectionStringBuilder str = new EntityConnectionStringBuilder() {
				Provider = "System.Data.SqlClient",
				Metadata = "res://*/DB.GRDB.csdl|res://*/DB.GRDB.ssdl|res://*/DB.GRDB.msl",
				ProviderConnectionString = string.Format(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename={0};integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework", FilePath)// sqlString.ToString()
			};

			return str.ConnectionString;
		}
	}
}