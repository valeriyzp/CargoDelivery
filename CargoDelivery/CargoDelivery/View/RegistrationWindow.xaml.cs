using System.Windows;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = new RegistrationWindowViewModel();
        }
    }
}
