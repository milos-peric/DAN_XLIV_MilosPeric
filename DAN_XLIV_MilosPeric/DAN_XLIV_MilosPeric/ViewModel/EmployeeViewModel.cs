using DAN_XLIV_MilosPeric.Command;
using DAN_XLIV_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIV_MilosPeric.ViewModel
{
    class EmployeeViewModel : ViewModelBase
    {
        ViewEmployeeView view;
        public EmployeeViewModel(ViewEmployeeView employeeView)
        {
            view = employeeView;
            PizzaCollection = PizzaItems.Load();
        }

        private double totalPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        private string customerID;
        public string CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        private PizzaItems pizzaItem;
        public PizzaItems PizzaItem
        {
            get { return pizzaItem; }
            set
            {
                pizzaItem = value;
                OnPropertyChanged("PizzaItem");
            }
        }

        private ObservableCollection<PizzaItems> pizzaCollection;
        public ObservableCollection<PizzaItems> PizzaCollection
        {
            get { return pizzaCollection; }
            set
            {
                pizzaCollection = value;
                OnPropertyChanged("PizzaCollection");
            }
        }

        private ObservableCollection<PizzaItems> selectedPizzaItems;
        public ObservableCollection<PizzaItems> SelectedPizzaItems
        {
            get { return selectedPizzaItems; }
            set
            {
                selectedPizzaItems = value;
                OnPropertyChanged("SelectedPizzaItems");
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(Logout);
                    return logoutCommand;
                }
                return logoutCommand;
            }
        }

        public void Logout(object obj)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want finish reviewing orders and logout?", "Confirmation", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        ViewLogin loginView = new ViewLogin();
                        Thread.Sleep(1000);
                        view.Close();
                        loginView.Show();
                        return;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
