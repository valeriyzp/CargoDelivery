using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CargoDelivery.Model;
using CargoDelivery.Command;
using CargoDelivery.View;

namespace CargoDelivery.ViewModel
{
    class ConsumerOrdersPageViewModel : INotifyPropertyChanged
    {
        public Consumer consumer { get; set; }
        public RelayCommand ShowSelectedOrderCommand { get; set; }

        public ObservableCollection<Order> ConsumerOrders
        {
            get { return consumer.getOrders(); }
        }

        public ConsumerOrdersPageViewModel(Consumer value)
        {
            consumer = value;
            ShowSelectedOrderCommand = new RelayCommand(ShowSelectedOrder);
        }

        public void ShowSelectedOrder(object obj)
        {
            ConsumerOrderInfoWindow window = new ConsumerOrderInfoWindow((Order)obj);
            window.ShowDialog();
            OnPropertyChanged("ConsumerOrders");
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
