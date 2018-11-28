using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace zLib {
	public class WindowWithOnResult : Window {
		public Action<System.Windows.Forms.DialogResult> OnResult = (r) => { };
		public Action<object> OnReturn = (o) => { };
	}
}
