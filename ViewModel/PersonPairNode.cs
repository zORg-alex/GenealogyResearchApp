using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class PersonPairNode : Notifiable {

		private float x;
		public float X { get { return x; } set { x = value; RaisePropertyChanged("X"); } }

		private float y;
		public float Y { get { return y; } set { y = value; RaisePropertyChanged("Y"); } }

		private Person male;
		public Person Male { get { return male; } set { male = value; RaisePropertyChanged("Male"); } }

		private Person female;
		public Person Female { get { return female; } set { female = value; RaisePropertyChanged("Female"); } }

		private UVMCommand expandBranch;
		public UVMCommand ExpandBranch { get { return expandBranch; } set { expandBranch = value; RaisePropertyChanged("ExpandBranch"); } }

		internal PersonPairNode MaleParentsPair;
		internal PersonPairNode FemaleParentsPair;
	}
}
