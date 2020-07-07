using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_MilosPeric.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow view;
        internal MainWindowViewModel(MainWindow view)
        {
            this.view = view;
        }
    }
}
