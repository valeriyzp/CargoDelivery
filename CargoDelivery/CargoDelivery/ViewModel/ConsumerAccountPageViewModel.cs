using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;

namespace CargoDelivery.ViewModel
{
    class ConsumerAccountPageViewModel
    {
        public Consumer consumer { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        public ConsumerAccountPageViewModel(Consumer value)
        {
            consumer = value;
            SaveChangesCommand = new RelayCommand(SaveChanges, IsValidChanges);
        }

        public void SaveChanges(object obj)
        {
            if (consumer.updateConsumerInfo()) MessageBox.Show("Changes saved");
            else MessageBox.Show("Something went wrong");
        }

        public bool IsValidChanges(object obj)
        {
            return consumer.IsValidAccountChangeInfo;
        }
    }
}
