using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;

namespace CargoDelivery.ViewModel
{
    class OperatorAddOrderToTruckWindowViewModel
    {
        public Operator Operator { get; set; }
        public string TruckID { get; set; }
        public string Number { get; set; }
        public RelayCommand AddOrderToTruckCommand { get; set; }
        public OperatorAddOrderToTruckWindowViewModel(Operator value)
        {
            Operator = value;
            AddOrderToTruckCommand = new RelayCommand(AddOrderToTruck);
        }

        public void AddOrderToTruck(object obj)
        {
            if (Operator.addOrderToTruckByTruckIdAndNumber(TruckID, Number)) MessageBox.Show("Order successfully added to truck");
            else MessageBox.Show("Unable to add order to truck");
        }
    }
}
