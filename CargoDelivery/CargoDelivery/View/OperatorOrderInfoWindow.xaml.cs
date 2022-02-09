using System.Windows;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для OperatorOrderInfoWindow.xaml
    /// </summary>
    public partial class OperatorOrderInfoWindow : Window
    {
        public OperatorOrderInfoWindow(Operator _operator, Order value)
        {
            InitializeComponent();
            DataContext = new OperatorOrderInfoWindowViewModel(_operator, value);
        }
    }
}
