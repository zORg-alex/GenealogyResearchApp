using System;

namespace zLib {
	public interface IDialogHelper {
		Func<string, string, string, string> OpenDialog { get; set; }
	}
}