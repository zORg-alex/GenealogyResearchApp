using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using zLib;
using GenealogyResearchApp.View;

namespace GenealogyResearchApp.View {
	public class DialogHelper : DependencyObject {
		public static string OpenDialog(string Type, string Filter, string Path) {
			FileDialog dlg = new OpenFileDialog();
			var fdlg = new System.Windows.Forms.FolderBrowserDialog();
			if (Type.ToLower() == "save") {
				dlg = new SaveFileDialog();
			}
			if (Type.ToLower() == "selectfolder") {
				fdlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
				fdlg.SelectedPath = Path;
				fdlg.Description = Filter;

				var fdres = fdlg.ShowDialog();

				if (fdres == System.Windows.Forms.DialogResult.OK || fdres == System.Windows.Forms.DialogResult.Yes) {
					return fdlg.SelectedPath;
				}
				return "";
			}
			dlg.InitialDirectory = Path;
			//Filter string should contain a description of the filter, 
			//followed by a vertical bar and the filter pattern. 
			//Must also separate multiple filter description and 
			//pattern pairs by a vertical bar. Must separate multiple 
			//extensions in a filter pattern with a semicolon. Example: 
			//"Image files (*.bmp, *.jpg)|*.bmp;*.jpg|All files (*.*)|*.*"
			dlg.Filter = Filter;
			if (dlg.ShowDialog() == true) {
				return dlg.FileName;
			}
			return "";
		}

		public static void OpenWindow(string Name, string OwnerName, Action<System.Windows.Forms.DialogResult> OnResult, string Title = "", string Text = "", Func<object, bool> Validator = null) {
			Type windowType = Type.GetType(Name, false, true);
			if (windowType == null) return;
			WindowWithOnResult w = (WindowWithOnResult)Activator.CreateInstance(windowType);
			w.DataContext = new WindowContext() { Title = Title, Text = Text, Validate = Validator };
			w.OnResult = OnResult;
			foreach (Window ww in App.Current.Windows) {
				if (ww.Name == OwnerName) w.Owner = ww;
			}
			w.ShowDialog();
		}
		public static void OpenWindowWithObject(string Name, string OwnerName, Action<System.Windows.Forms.DialogResult> OnResult, object Context, Func<object, bool> Validator = null) {
			Type windowType = Type.GetType(Name, false, true);
			if (windowType == null) return;
			WindowWithOnResult w = (WindowWithOnResult)Activator.CreateInstance(windowType);
			w.DataContext = Context;
			w.OnResult = OnResult;
			foreach (Window ww in App.Current.Windows) {
				if (ww.Name == OwnerName) w.Owner = ww;
			}
			w.ShowDialog();
		}

		public static void OpenWindowWithReturn(string Name, object DataContext, string OwnerName, Action<System.Windows.Forms.DialogResult> OnResult, Action<object> OnReturn, string Title = "", string Text = "", Func<object, bool> Validator = null) {
			Type windowType = Type.GetType(Name, false, true);
			if (windowType == null) return;
			WindowWithOnResult w = (WindowWithOnResult)Activator.CreateInstance(windowType);
			w.DataContext = new WindowContext() { Object = DataContext, Title = Title, Text = Text, Validate = Validator };
			w.OnResult = OnResult;
			w.OnReturn = OnReturn;
			foreach (Window ww in App.Current.Windows) {
				if (ww.Name == OwnerName) w.Owner = ww;
			}
			w.ShowDialog();
		}

		public class WindowContext : Notifiable {

			private string title;
			public string Title { get { return title; } set { title = value; RaisePropertyChanged("Title"); } }

			private string text;
			public string Text { get { return text; } set { text = value; RaisePropertyChanged("Text"); } }

			private object _object;
			public object Object { get { return _object; } set { _object = value; RaisePropertyChanged("Object"); } }

			public Func<object, bool> Validate;
		}
	}
}