using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GRAppLib.DB;
using zLib;

namespace GenealogyResearchApp.View.Controls {
	public class PersonTreeView : TreeView, INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string propertyName) {
			// take a copy to prevent thread issues
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		static PersonTreeView() {
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PersonTreeView), new FrameworkPropertyMetadata(typeof(PersonTreeView)));
			
		}

		public Person RootPerson {
			get { return (Person)GetValue(RootPersonProperty); }
			set { SetValue(RootPersonProperty, value); }
		}
		public static readonly DependencyProperty RootPersonProperty =
			DependencyProperty.Register(
				"RootPerson", 
				typeof(Person), 
				typeof(PersonTreeView), 
				new FrameworkPropertyMetadata(
					new Person(), 
					new PropertyChangedCallback(OnRootPersonChanged)
					)
				);

		private static void UpdateLayout(DependencyObject d) {
			var l = (d.GetValue(ItemsSourceProperty) as IEnumerable<object>).ToList();
			float minX = 0; float minY = 0;
			float maxX = 0; float maxY = 0;
			foreach (CanvasObject o in l) {
				minX = Math.Min(minX, o.X);
				minY = Math.Min(minY, o.Y);
				maxX = Math.Max(maxX, o.X);
				maxY = Math.Max(maxY, o.Y);
			}
			//TODO Fix layout
		}

		private static void OnRootPersonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			Person p = e.NewValue as Person;
			CanvasObject r = new CanvasObject();
			if (p.Gender == 0) {
				r.Male = p;
				r.Female = p.Spouse;
			} else {
				r.Female = p;
				r.Male = p.Spouse;
			}
			if (r.Male != null) {
				r.MaleParentsPair = new CanvasObject() {
					Male = r.Male.Father,
					Female = r.Male.Mother,
					ExpandBranch = new UVMCommand(par=> ExpandNode(d, r.MaleParentsPair))
				};
			}
			if (r.Female != null) { 
				r.FemaleParentsPair = new CanvasObject() {
					Male = r.Female.Father,
					Female = r.Female.Mother,
					ExpandBranch = new UVMCommand(par => ExpandNode(d, r.FemaleParentsPair))
				};
			}
			List<object> l = new List<object>();
			l.Add(r);
			d.SetValue(ItemsSourceProperty, l);
			UpdateLayout(d);
		}
		
		static void ExpandNode(DependencyObject d, CanvasObject o) {
			o.ExpandBranch = new UVMCommand(p => {
				var l = (d.GetValue(ItemsSourceProperty) as IEnumerable<object>).ToList();
				if (o.Male != null) {
					if (o.MaleParentsPair != null)
						o.MaleParentsPair = new CanvasObject() {
							X = o.X + 200,
							Y = o.Y - 100,
							Male = o.Male.Father,
							Female = o.Male.Mother
						};
					l.Add(o.MaleParentsPair);
					ExpandNode(d, o.MaleParentsPair);
				}
				if (o.Female != null) {
					if (o.FemaleParentsPair != null)
						o.FemaleParentsPair = new CanvasObject() {
							X = o.X + 200,
							Y = o.Y + 100,
							Male = o.Female.Father,
							Female = o.Female.Mother
						};
					l.Add(o.FemaleParentsPair);
					ExpandNode(d, o.FemaleParentsPair);
				}
				d.SetValue(ItemsSourceProperty, l);
				UpdateLayout(d);
			});
			o.CollapseBranch = new UVMCommand(p=> {
				var l = (d.GetValue(ItemsSourceProperty) as IEnumerable<object>).ToList();
				l.Remove(o.MaleParentsPair);
				l.Remove(o.FemaleParentsPair);
				d.SetValue(ItemsSourceProperty, l);
				UpdateLayout(d);
			});
		}


		class CanvasObject : Notifiable {

			private float x;
			public float X { get { return x; } set { x = value; RaisePropertyChanged("X"); } }

			private float y;
			public float Y { get { return y; } set { y = value; RaisePropertyChanged("Y"); } }

			private bool isExpanded;
			public bool IsExpanded { get { return isExpanded; } set {
					isExpanded = value;
					if (IsExpanded)
						ExpandBranch.Execute(null);
					else {
						CollapseBranch.Execute(null);
					}
					RaisePropertyChanged("IsExpanded");
				}
			}

			private Person male;
			public Person Male { get { return male; } set { male = value; RaisePropertyChanged("Male"); } }

			private Person female;
			public Person Female { get { return female; } set { female = value; RaisePropertyChanged("Female"); } }

			private UVMCommand expandBranch;
			public UVMCommand ExpandBranch { get { return expandBranch; } set { expandBranch = value; RaisePropertyChanged("ExpandBranch"); } }

			private UVMCommand collapseBranch;
			public UVMCommand CollapseBranch { get { return collapseBranch; } set { collapseBranch = value; RaisePropertyChanged("CollapseBranch"); } }

			internal CanvasObject MaleParentsPair;
			internal CanvasObject FemaleParentsPair;
		}
	}
}
