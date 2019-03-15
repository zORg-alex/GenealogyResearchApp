using System;
using System.Windows.Forms;

namespace zLib {
	public interface IDialogHelper {
		Func<string, string, string, string> OpenDialog { get; set; }
		//ClassName, DataContext, OwnerName, ResultAction, Title, Message, Validation
		Action<string, string, Action<System.Windows.Forms.DialogResult>, string, string, Func<object, bool>> OpenWindow { get; set; }
		Action<string, string, Action<DialogResult>, object, Func<object, bool>> OpenWindowWithObject { get; set; }
		Action<string, object, string, Action<System.Windows.Forms.DialogResult>, Action<object>, string, string, Func<object, bool>> OpenWindowWithReturn { get; set; }
	}
}