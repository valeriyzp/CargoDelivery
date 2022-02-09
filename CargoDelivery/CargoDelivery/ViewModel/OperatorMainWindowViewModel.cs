using System.Windows;
using CargoDelivery.Command;
using CargoDelivery.Model;
using CargoDelivery.View;

namespace CargoDelivery.ViewModel
{
    class OperatorMainWindowViewModel
    {
        public Operator Operator {get; set;}
        public string Number {get; set;}
        public RelayCommand FindOrderCommand { get; set; }
        public RelayCommand TruckArrivalCommand { get; set; }
        public RelayCommand AddOrderToTruckCommand { get; set; }
        public RelayCommand NewOrderCommand { get; set; }

        public OperatorMainWindowViewModel(Operator value)
        {
            Operator = value;
            FindOrderCommand = new RelayCommand(FindOrder);
            TruckArrivalCommand = new RelayCommand(TruckArrival);
            AddOrderToTruckCommand = new RelayCommand(AddOrderToTruck);
            NewOrderCommand = new RelayCommand(NewOrder);
        }

        public void FindOrder(object obj)
        {
            Order order = Operator.getOrderByOrderNumber(Number);
            if(order != null)
            {
                OperatorOrderInfoWindow window = new OperatorOrderInfoWindow(Operator, order);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("This order not found");
            }
        }

        public void TruckArrival(object obj)
        {
            OperatorTruckArrivalWindow window = new OperatorTruckArrivalWindow(Operator);
            window.ShowDialog();
        }

        public void AddOrderToTruck(object obj)
        {
            OperatorAddOrderToTruckWindow window = new OperatorAddOrderToTruckWindow(Operator);
            window.ShowDialog();
        }

        public void NewOrder(object obj)
        {
            OperatorNewOrderWindow window = new OperatorNewOrderWindow(Operator);
            window.ShowDialog();
        }
    }
}
