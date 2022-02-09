using CargoDelivery.Command;
using CargoDelivery.Model;
using CargoDelivery.View;
using System.Windows;

namespace CargoDelivery.ViewModel
{
    class ConsumerTrackingPageViewModel
    {
        public string Number { get; set; }
        public Consumer consumer { get; set; }
        public Order NewOrder { get; set; }
        public RelayCommand FindOrderCommand { get; set; }

        public ConsumerTrackingPageViewModel(Consumer value)
        {
            consumer = value;
            NewOrder = new Order();
            FindOrderCommand = new RelayCommand(FindOrder);
        }

        public void FindOrder(object obj)
        {
            Order order = consumer.getOrderByNumber(Number);
            if(order != null)
            {
                ConsumerOrderInfoWindow window = new ConsumerOrderInfoWindow(order);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("This order not found");
            }
        }
    }
}
