using System.Windows.Controls;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;


namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumerNewOrderPage.xaml
    /// </summary>
    public partial class ConsumerNewOrderPage : Page
    {
        public ConsumerNewOrderPage(Consumer value)
        {
            InitializeComponent();
            DataContext = new ConsumerNewOrderPageViewModel(value);
        }
    }
}
