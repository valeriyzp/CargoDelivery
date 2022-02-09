using System.Windows;
using CargoDelivery.Model;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для OperatorAddOrderToTruckWindow.xaml
    /// </summary>
    public partial class OperatorAddOrderToTruckWindow : Window
    {
        public OperatorAddOrderToTruckWindow(Operator value)
        {
            InitializeComponent();
            DataContext = new OperatorAddOrderToTruckWindowViewModel(value);
        }
    }
}
