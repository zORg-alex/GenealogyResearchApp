using GenealogyResearchApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GenealogyResearchApp.View.CustomControls {
	/// <summary>
	/// Interaction logic for NameBox.xaml
	/// </summary>
	public partial class NameBox : UserControl {
		public NameBox() {
			InitializeComponent();
			IsKeyboardFocusWithinChanged += NameBox_IsKeyboardFocusWithinChanged;
			NamePopup.IsKeyboardFocusWithinChanged += NamePopup_IsKeyboardFocusWithinChanged;
			NameGroupPopup.IsKeyboardFocusWithinChanged += NameGroupPopup_IsKeyboardFocusWithinChanged;
		}
		int namePopupFocus = 0;
		int NamePopupFocus {
			get { return namePopupFocus; }
			set {
				namePopupFocus = value;
				if (namePopupFocus <= 0) {
					namePopupFocus = 0;
					SetValue(IsNamePopupOpenProperty, false);
				} else {
					SetValue(IsNamePopupOpenProperty, true);
				}
			}
		}

		private void NameGroupPopup_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
			if ((bool)e.NewValue == false) SetValue(IsNameGroupPopupOpenProperty, false);
		}

		private void NamePopup_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
			var disp = Dispatcher;
			if ((bool)e.NewValue == true) NamePopupFocus++;
			if ((bool)e.NewValue == false) Task.Delay(15).ContinueWith((t) => disp.Invoke(() => NamePopupFocus--));
			Console.WriteLine("NamePopup_IsKeyboardFocusWithinChanged" + NamePopupFocus);
		}

		private void NameBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) {
			var disp = Dispatcher;
			if ((bool)e.NewValue == true) NamePopupFocus++;
			if ((bool)e.NewValue == false) Task.Delay(15).ContinueWith((t) => disp.Invoke(()=> NamePopupFocus--)); 
			Console.WriteLine("NameBox_IsKeyboardFocusWithinChanged" + NamePopupFocus);
		}

		public bool IsNamePopupOpen {
			get { return (bool)GetValue(IsNamePopupOpenProperty); }
			set { SetValue(IsNamePopupOpenProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsNamePopupOpen.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsNamePopupOpenProperty =
			DependencyProperty.Register("IsNamePopupOpen", typeof(bool), typeof(NameBox), new PropertyMetadata(false, IsNamePopupOpenPropertyChanged));

		private static void IsNamePopupOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			
		}

		public bool IsNameGroupPopupOpen {
			get { return (bool)GetValue(IsNameGroupPopupOpenProperty); }
			set { SetValue(IsNameGroupPopupOpenProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsNameGroupPopupOpen.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsNameGroupPopupOpenProperty =
			DependencyProperty.Register("IsNameGroupPopupOpen", typeof(bool), typeof(NameBox), new PropertyMetadata(false, IsNameGroupPopupOpenChanged));

		private static void IsNameGroupPopupOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			if ((bool)e.NewValue == true) {
				d.Dispatcher.Invoke(() => {
					Keyboard.Focus(((NameBox)d).NGPFilter);
					((NameBox)d).SetValue(IsNamePopupOpenProperty, false);
				});
			}
		}
	}
}
