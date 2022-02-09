using System.Windows;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel();
        }
    }
}
