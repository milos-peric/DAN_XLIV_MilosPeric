using DAN_XLIV_MilosPeric.Command;
using DAN_XLIV_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            pizzaItem = new tblPizzaMenu();
            pizzaItem2 = new tblSelectedPizza();
            

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


        private tblPizzaMenu pizzaItem;
        public tblPizzaMenu PizzaItem
        {
            get { return pizzaItem; }
            set
            {
                pizzaItem = value;
                OnPropertyChanged("PizzaItem");
            }
        }

        private List<tblPizzaMenu> pizzaCollection;
        public List<tblPizzaMenu> PizzaCollection
        {
            get { return pizzaCollection; }
            set
            {
                pizzaCollection = value;
                OnPropertyChanged("PizzaCollection");
            }
        }

        private tblSelectedPizza pizzaItem2;
        public tblSelectedPizza PizzaItem2
        {
            get { return pizzaItem2; }
            set
            {
                pizzaItem2 = value;
                OnPropertyChanged("PizzaItem2");
            }
        }

        private List<tblSelectedPizza> selectedPizzaItems;
        public List<tblSelectedPizza> SelectedPizzaItems
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
            PizzaCollection = dBService.GetPizzaMenu();
        }


        //private ICommand addCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (addCommand == null)
        //        {
                    
        //            addCommand = new RelayCommand(Add);
        //            return addCommand;
        //        }
        //        return loadCommand;
        //    }
        //}

        //public void Add(object obj)
        //{
        //    SelectedPizzaItems = new List<tblPizzaMenu>();
        //    PizzaItem2 = dBService.GetPizzaByID(PizzaItem.ID);
        //    SelectedPizzaItems.Add(PizzaItem2);
        //    Debug.WriteLine("Added: " + PizzaItem.PizzaName);
        //}

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
                    //PizzaItem2 = dBService.GetPizzaByID(PizzaItem.ID);
                    TotalPrice += double.Parse(pizzaItem.Price);
                    dBService.AddToSelectedMenu(PizzaItem);
                    SelectedPizzaItems = dBService.GetSelected();
                    Debug.WriteLine("Added: " + PizzaItem.PizzaName);
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
                    
                    TotalPrice -= double.Parse(pizzaItem.Price);
                    if (TotalPrice < 0)
                    {
                        TotalPrice = 0;
                    }
                    dBService.RemoveSelectedPizza(PizzaItem2.ID);
                    SelectedPizzaItems = dBService.GetSelected();
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
