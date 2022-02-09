using System.Windows;
using CargoDelivery.Model;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для OperatorTruckArrivalWindow.xaml
    /// </summary>
    public partial class OperatorTruckArrivalWindow : Window
    {
        public OperatorTruckArrivalWindow(Operator value)
        {
            InitializeComponent();
            DataContext = new OperatorTruckArrivalWindowViewModel(value);
        }
    }
}
