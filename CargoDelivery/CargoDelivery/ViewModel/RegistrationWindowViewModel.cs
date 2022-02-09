using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CargoDelivery.ViewModel
{
    class RegistrationWindowViewModel : INotifyPropertyChanged
    {
        private Consumer _consumer;
        public Consumer consumer
        {
            get { return _consumer; }
            set
            {
                if(_consumer != value)
                {
                    _consumer = value;
                    OnPropertyChanged("consumer");
                }
            }
        }
        public RelayCommand SignUpCommand { get; set; }

        public RegistrationWindowViewModel()
        {
            consumer = new Consumer();
            SignUpCommand = new RelayCommand(SignUp, IsValidData);
        }

        public void SignUp(object obj)
        {
            if (consumer.registerNewConsumer())
            {
                MessageBox.Show("You have successfully registered");
                consumer = new Consumer();
            }
            else MessageBox.Show("Username or phone number or email are already registered");
        }

        public bool IsValidData(object obj)
        {
            return consumer.IsValid;
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
