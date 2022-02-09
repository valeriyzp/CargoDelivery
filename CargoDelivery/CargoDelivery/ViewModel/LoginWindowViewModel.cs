using System.ComponentModel;
using System.Runtime.CompilerServices;
using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;
using CargoDelivery.View;

namespace CargoDelivery.ViewModel
{
    class LoginWindowViewModel : INotifyPropertyChanged
    {
        private User _user;
        public User user
        {
            get { return _user; }
            set
            {
                if(_user != value)
                {
                    _user = value;
                    OnPropertyChanged("user");
                }
            }
        }
        public RelayCommand SignInCommand { get; private set; }
        public RelayCommand CreateAccountCommand { get; private set; }

        public LoginWindowViewModel()
        {
            user = new User();
            SignInCommand = new RelayCommand(SignIn, IsValidData);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        public void SignIn(object obj)
        {
            if (user.isLoginAsUser()) LoginAsUser();
            else if (user.isLoginAsAdmin()) LoginAsAdmin();
            else MessageBox.Show("Username or password is incorrect");
        }

        public bool IsValidData(object obj)
        {
            return user.IsValid;
        }

        public void LoginAsUser()
        {
            ConsumerMainWindow window = new ConsumerMainWindow(user.getConsumer());
            user = new User();
            window.ShowDialog();
        }

        public void LoginAsAdmin()
        {
            OperatorMainWindow window = new OperatorMainWindow(user.getOperator());
            user = new User();
            window.ShowDialog();
        }

        public void CreateAccount(object obj)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.ShowDialog();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
