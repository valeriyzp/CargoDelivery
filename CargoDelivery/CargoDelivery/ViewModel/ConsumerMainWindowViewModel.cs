using CargoDelivery.View;
using System.Windows.Controls;
using CargoDelivery.Command;
using System.ComponentModel;
using CargoDelivery.Model;
using System.Runtime.CompilerServices;

namespace CargoDelivery.ViewModel
{
    public enum PageNumbers
    {
        OrdersPage,
        NewOrderPage,
        TrackingPage,
        AccountPage
    };

    class ConsumerMainWindowViewModel : INotifyPropertyChanged
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
        public RelayCommand GoToOrdersCommand { get; set; }
        public RelayCommand GoToNewOrderCommand { get; set; }
        public RelayCommand GoToAccountCommand { get; set; }
        public RelayCommand GoToTrackingCommand { get; set; }

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        PageNumbers CurrentPageType;

        public ConsumerMainWindowViewModel(Consumer value)
        {
            consumer = value;

            GoToOrdersCommand = new RelayCommand(GoToOrders);
            GoToNewOrderCommand = new RelayCommand(GoToNewOrder);
            GoToAccountCommand = new RelayCommand(GoToAccount);
            GoToTrackingCommand = new RelayCommand(GoToTracking);

            CurrentPage = new ConsumerOrdersPage(consumer);
            CurrentPageType = PageNumbers.OrdersPage;
        }

        public void GoToOrders(object obj)
        {
            if (CurrentPageType == PageNumbers.OrdersPage)
                return;
            if (CurrentPageType == PageNumbers.AccountPage) consumer = consumer.getConsumerInfo();
            CurrentPageType = PageNumbers.OrdersPage;
            CurrentPage = new ConsumerOrdersPage(consumer);
        }

        public void GoToNewOrder(object obj)
        {
            if (CurrentPageType == PageNumbers.NewOrderPage)
                return;
            if (CurrentPageType == PageNumbers.AccountPage) consumer = consumer.getConsumerInfo();
            CurrentPageType = PageNumbers.NewOrderPage;
            CurrentPage = new ConsumerNewOrderPage(consumer);
        }

        public void GoToAccount(object obj)
        {
            if (CurrentPageType == PageNumbers.AccountPage)
            {
                consumer = consumer.getConsumerInfo();
                return;
            }
            CurrentPageType = PageNumbers.AccountPage;
            CurrentPage = new ConsumerAccountPage(consumer);
        }

        public void GoToTracking(object obj)
        {
            if (CurrentPageType == PageNumbers.TrackingPage)
                return;
            if (CurrentPageType == PageNumbers.AccountPage) consumer = consumer.getConsumerInfo();
            CurrentPageType = PageNumbers.TrackingPage;
            CurrentPage = new ConsumerTrackingPage(consumer);
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
