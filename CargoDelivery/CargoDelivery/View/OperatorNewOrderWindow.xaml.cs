using System.Windows;
using CargoDelivery.Model;
using CargoDelivery.ViewModel;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для OperatorNewOrderWindow.xaml
    /// </summary>
    public partial class OperatorNewOrderWindow : Window
    {
        public OperatorNewOrderWindow(Operator value)
        {
            InitializeComponent();
            DataContext = new OperatorNewOrderWindowViewModel(value);
        }
    }
}
