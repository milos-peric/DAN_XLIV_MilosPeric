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
    class GuestViewModel : ViewModelBase
    {
        ViewGuestView view;
        DBService dBService = new DBService();
        public GuestViewModel(ViewGuestView guestView)
        {
            view = guestView;
            selectedPizzaItems = new ObservableCollection<PizzaItems>();
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

        private ICommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(Load);
                    return loadCommand;
                }
                return loadCommand;
            }
        }

        public void Load(object obj)
        {
            PizzaCollection = PizzaItems.Load();
        }

        private ICommand addItem;
        public ICommand AddItem
        {
            get
            {
                if (addItem == null)
                {
                    addItem = new RelayCommand(param => AddItemExecute(), param => CanAddItemExecute());
                }
                return addItem;
            }
        }

        private void AddItemExecute()
        {
            try
            {
                if (PizzaItem != null)
                {
                    selectedPizzaItems.Add(pizzaItem);
                    TotalPrice += double.Parse(pizzaItem.Price.Substring(1));
                    MessageBox.Show($"{pizzaItem.Name} added to cart.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddItemExecute()
        {
            if (PizzaItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand removeItem;
        public ICommand RemoveItem
        {
            get
            {
                if (removeItem == null)
                {
                    removeItem = new RelayCommand(param => RemoveItemExecute(), param => CanRemoveItemExecute());
                }
                return removeItem;
            }
        }

        private void RemoveItemExecute()
        {
            try
            {
                if (PizzaItem != null)
                {
                    TotalPrice -= double.Parse(pizzaItem.Price.Substring(1));
                    selectedPizzaItems.Remove(pizzaItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRemoveItemExecute()
        {
            if (PizzaItem == null)
            {
                return false;
            }
            else
            {
                return true;
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to place order and logout?", "Confirmation", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        ViewLogin loginView = new ViewLogin();
                        MessageBox.Show($"Order placed successfully.", "Success");
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
