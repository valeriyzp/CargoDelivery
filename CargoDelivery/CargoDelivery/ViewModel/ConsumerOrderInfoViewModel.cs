using CargoDelivery.Model;
using CargoDelivery.Command;

namespace CargoDelivery.ViewModel
{
    class ConsumerOrderInfoViewModel
    {
        public Order order { get; set; }
        public RelayCommand CancelOrderCommand { get; set; }

        public ConsumerOrderInfoViewModel(Order value)
        {
            order = value;
            CancelOrderCommand = new RelayCommand(CancelOrder, CanCancelOrder);
        }

        public void CancelOrder(object obj)
        {
            Consumer consumer = new Consumer();
            if(consumer.cancelOrder(order.ID))
            {
                order.IsDenied = true;
                order.Status = "Canceled";
                order.IsPaid = false;
            }
        }

        public bool CanCancelOrder(object obj)
        {
            if (order.IsDenied || order.IsReceived) return false;
            return true;
        }
    }
}
