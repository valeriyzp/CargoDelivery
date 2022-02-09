using System.Windows.Controls;
using CargoDelivery.Model;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumerTrackingPage.xaml
    /// </summary>
    public partial class ConsumerTrackingPage : Page
    {
        public ConsumerTrackingPage(Consumer consumer)
        {
            InitializeComponent();
            DataContext = new ConsumerTrackingPageViewModel(consumer);
        }
    }
}
