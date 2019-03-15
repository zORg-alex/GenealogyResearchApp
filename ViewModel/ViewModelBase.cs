using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zLib;

namespace GenealogyResearchApp.ViewModel {
	public class ViewModelBase : Notifiable, IDialogHelper, IType {

		public string Type { get { return GetType().Name; } }

		public static Func<string, string, string, string> _openDialog;
		public static Action<string, string, Action<System.Windows.Forms.DialogResult>, string, string, Func<object, bool>> _openWindow;
		public static Action<string, string, Action<System.Windows.Forms.DialogResult>, object, Func<object, bool>> _openWindowWithObject;
		public static Action<string, object, string, Action<System.Windows.Forms.DialogResult>, Action<object>, string, string, Func<object, bool>> _openWindowWithReturn;

		public Func<string, string, string, string> OpenDialog { get { return _openDialog; } set { _openDialog = value; } }
		public Action<string, string, Action<DialogResult>, string, string, Func<object, bool>> OpenWindow { get { return _openWindow; } set { _openWindow = value; } }
		public Action<string, string, Action<DialogResult>, object, Func<object, bool>> OpenWindowWithObject { get { return _openWindowWithObject; } set { _openWindowWithObject = value; } }
		public Action<string, object, string, Action<DialogResult>, Action<object>, string, string, Func<object, bool>> OpenWindowWithReturn { get { return _openWindowWithReturn; } set { _openWindowWithReturn = value; } }

		public void Update(UpdateTarget Target) {

		}

	}
}
