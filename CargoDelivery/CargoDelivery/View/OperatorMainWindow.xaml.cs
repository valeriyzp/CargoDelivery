using System.Windows;
using CargoDelivery.ViewModel;
using CargoDelivery.Model;

namespace CargoDelivery.View
{
    /// <summary>
    /// Логика взаимодействия для OperatorMainWindow.xaml
    /// </summary>
    public partial class OperatorMainWindow : Window
    {
        public OperatorMainWindow(Operator value)
        {
            InitializeComponent();
            DataContext = new OperatorMainWindowViewModel(value);
        }
    }
}
