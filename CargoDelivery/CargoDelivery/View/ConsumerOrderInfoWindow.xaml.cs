using System.Windows;
using CargoDelivery.Model;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для UserOrderInfoWindow.xaml
    /// </summary>
    public partial class ConsumerOrderInfoWindow : Window
    {
        public ConsumerOrderInfoWindow(Order value)
        {
            InitializeComponent();
            DataContext = new ConsumerOrderInfoViewModel(value);
        }
    }
}
