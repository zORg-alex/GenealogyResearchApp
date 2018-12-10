namespace GRAppLib.DB {
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	public partial class GRDBCont : DbContext {
		public GRDBCont(string Path)
			: base(ConnectionString.Connect(Path)) {
		}
	}
}
