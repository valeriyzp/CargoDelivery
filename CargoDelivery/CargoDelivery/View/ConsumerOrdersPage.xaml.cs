using System.Windows.Controls;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumerOrdersPage.xaml
    /// </summary>
    public partial class ConsumerOrdersPage : Page
    {
        public ConsumerOrdersPage(Consumer value)
        {
            InitializeComponent();
            DataContext = new ConsumerOrdersPageViewModel(value);
        }
    }
}
