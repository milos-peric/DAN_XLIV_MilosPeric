using DAN_XLIV_MilosPeric.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DAN_XLIV_MilosPeric.View
{
    /// <summary>
    /// Interaction logic for ViewGuestView.xaml
    /// </summary>
    public partial class ViewGuestView : Window
    {
        public ViewGuestView()
        {
            InitializeComponent();
            DataContext = new GuestViewModel(this);
        }
    }
}
