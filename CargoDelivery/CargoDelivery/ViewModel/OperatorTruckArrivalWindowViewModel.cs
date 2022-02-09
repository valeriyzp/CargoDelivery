using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;

namespace CargoDelivery.ViewModel
{
    class OperatorTruckArrivalWindowViewModel
    {
        public Operator Operator { get; set; }
        public string TruckID { get; set; }
        public RelayCommand TruckArrivalConfirmCommand { get; set; }

        public OperatorTruckArrivalWindowViewModel(Operator value)
        {
            Operator = value;
            TruckArrivalConfirmCommand = new RelayCommand(TruckArrivalConfirm);
        }

        public void TruckArrivalConfirm(object obj)
        {
            if (Operator.setTruckArrival(TruckID)) MessageBox.Show("Delivery successfully completed");
            else  MessageBox.Show("Truck id does not exist or delivery has already been completed");
        }

    }
}
