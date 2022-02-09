using System.Windows.Controls;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumerAccountPage.xaml
    /// </summary>
    public partial class ConsumerAccountPage : Page
    {
        public ConsumerAccountPage(Consumer consumer)
        {
            InitializeComponent();
            DataContext = new ConsumerAccountPageViewModel(consumer);
        }
    }
}
