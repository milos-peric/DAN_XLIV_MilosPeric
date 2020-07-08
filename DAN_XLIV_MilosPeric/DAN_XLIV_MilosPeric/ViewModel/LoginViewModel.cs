using DAN_XLIV_MilosPeric.Command;
using DAN_XLIV_MilosPeric.Validation;
using DAN_XLIV_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIV_MilosPeric.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        ViewLogin view;

        public LoginViewModel(ViewLogin viewLogin)
        {
            view = viewLogin;
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute, param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (UserName.Equals("1") && password.Equals("1"))
                {
                    ViewEmployeeView employeeView = new ViewEmployeeView();
                    view.Close();
                    employeeView.Show();
                    return;
                }
                else if (UserName.Equals("2") && password.Equals("2"))
                {
                    ViewGuestView guestView = new ViewGuestView();
                    view.Close();
                    guestView.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong usename or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
