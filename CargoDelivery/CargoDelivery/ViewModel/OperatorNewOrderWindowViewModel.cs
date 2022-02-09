using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CargoDelivery.ViewModel
{
    class OperatorNewOrderWindowViewModel : INotifyPropertyChanged
    {
        public Operator Operator { get; set; }

        private Order newOrder;
        public Order NewOrder
        {
            get { return newOrder; }
            set
            {
                if (newOrder != value)
                {
                    newOrder = value;
                    OnPropertyChanged("NewOrder");
                }
            }
        }
        public RelayCommand SubmitNewOrderCommand { get; set; }

        public OperatorNewOrderWindowViewModel(Operator value)
        {
            Operator = value;
            SubmitNewOrderCommand = new RelayCommand(AddNewOrder, IsValidNewOrder);
            NewOrder = new Order();
        }

        public void AddNewOrder(object obj)
        {
            if (Operator.addOrder(NewOrder))
            {
                MessageBox.Show("You have successfully added a new order");
                NewOrder = new Order();
            }
            else MessageBox.Show("Something went wrong...");
        }

        public bool IsValidNewOrder(object obj)
        {
            return NewOrder.IsValid;
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
