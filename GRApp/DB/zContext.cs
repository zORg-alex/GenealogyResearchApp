using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyResearchApp.GRAppLib.DB {
	public class zContext {
		string path = "";
		[JsonIgnore]
		string Path { get { return path; } set { path = value; } }

		public zContext() {

		}

		public static zContext Deserialize(string Path) {
			zContext c;
			try {
				//TODO check if bk file exists and is older than current one
				using (StreamReader file = File.OpenText(Path)) {
					c = (zContext)new JsonSerializer().Deserialize(file, typeof(zContext));
				}
			} catch {
				c = new zContext();
			}
			c.Path = Path;
			return c;
		}

		public static void Serialize(zContext cont) {
			Directory.CreateDirectory(cont.Path.Substring(0, cont.Path.LastIndexOf("\\")));
			using (StreamWriter file = File.CreateText(cont.Path + "_")) {
				new JsonSerializer().Serialize(file, cont);
			}
			File.Replace(cont.Path + "_", cont.Path, cont.Path + ".bk");
			File.Delete(cont.Path + ".bk");
		}

		public void SaveChanges() {
			Serialize(this);
		}

		private List<Event> events = new List<Event>();
		public List<Event> Events { get { return events; } set { events = value; } }

		private List<NameGroup> nameGroups = new List<NameGroup>();
		public List<NameGroup> NameGroups { get { return nameGroups; } set { nameGroups = value; } }

		private List<Name> names = new List<Name>();
		public List<Name> Names { get { return names; } set { names = value; } }

		private List<Person> persons = new List<Person>();
		public List<Person> Persons { get { return persons; } set { persons = value; } }

		private List<Place> places = new List<Place>();
		public List<Place> Places { get { return places; } set { places = value; } }

	}
}
