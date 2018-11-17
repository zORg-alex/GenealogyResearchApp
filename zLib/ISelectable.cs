using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zLib {
	interface ISelectable {
		bool IsSelected { get; set; }
		bool IsExpanded { get; set; }
        int Depth { get; set; }
	}
}
