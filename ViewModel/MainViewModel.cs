using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zLib;

namespace GenealogyResearchApp.ViewModel
{
    public class MainViewModel : Notifiable, IDialogHelper {

        Func<string, string, string, string> _openDialog = (type, filter, path) => { return ""; };
        public Func<string, string, string, string> OpenDialog { get { return _openDialog; } set { _openDialog = value; } }

    }
}
