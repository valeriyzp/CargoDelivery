using System.Windows;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumerMainWindow.xaml
    /// </summary>
    public partial class ConsumerMainWindow : Window
    {
        public ConsumerMainWindow(Consumer value)
        {
            InitializeComponent();
            DataContext = new ConsumerMainWindowViewModel(value);
        }
    }
}
