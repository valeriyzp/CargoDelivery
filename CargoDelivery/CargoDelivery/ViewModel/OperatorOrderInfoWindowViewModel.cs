using System.ComponentModel;
using System.Runtime.CompilerServices;
using CargoDelivery.Model;
using CargoDelivery.Command;
using System.Windows;

namespace CargoDelivery.ViewModel
{
    class OperatorOrderInfoWindowViewModel : INotifyPropertyChanged
    {
        public Operator Operator {get; set;}
        private Order _order;
        public Order order
        {
            get { return _order; }
            set
            {
                if(_order != value)
                {
                    _order = value;
                    OnPropertyChanged("Order");
                    OnPropertyChanged("OrderInfo");

                }
            }
        }
        public string OrderInfo
        {
            get
            {
                return OrderToString(order);
            }
            set
            {
                ;
            }
        }
        public RelayCommand PaymentCommand { get; set; }
        public RelayCommand ReceiveCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        public OperatorOrderInfoWindowViewModel(Operator _operator, Order value)
        {
            Operator = _operator;
            order = value;
            PaymentCommand = new RelayCommand(Payment, canPayment);
            ReceiveCommand = new RelayCommand(Receive, canReceive);
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        public void Payment(object obj)
        {
            Operator.payForOrder(order.ID);
            order = Operator.getOrderByOrderNumber(order.Number);
        }

        public bool canPayment(object obj)
        {
            if (order.IsDenied || order.IsPaid) return false;
            else return true;
        }

        public void Receive(object obj)
        {
            Operator.receiveOrder(order.ID);
            order = Operator.getOrderByOrderNumber(order.Number);
        }

        public bool canReceive(object obj)
        {
            if (order.IsDenied || !order.IsPaid || order.IsReceived || order.Status != "Delivered") return false;
            else return true;
        }

        public void SaveChanges(object obj)
        {
            if(Operator.updateOrder(order)) MessageBox.Show("Changes saved");
            else MessageBox.Show("Something went wrong");
            order = Operator.getOrderByOrderNumber(order.Number);
        }

        // Unused, but useful
        public string OrderToString(Order InputValue)
        {
            string OutputValue = "";

            OutputValue += string.Format("Order number: {0}\n\n", InputValue.Number);

            OutputValue += string.Format("From: {0}\n", InputValue.SenderFirstPlusLastName);
            OutputValue += string.Format("{0}\n", InputValue.SenderPhoneNumber);
            OutputValue += string.Format("{0}\n\n", InputValue.SenderCity);

            OutputValue += string.Format("To: {0}\n", InputValue.ReceiverFirstPlusLastName);
            OutputValue += string.Format("{0}\n", InputValue.ReceiverPhoneNumber);
            OutputValue += string.Format("{0}\n\n", InputValue.ReceiverCity);

            OutputValue += string.Format("Type: {0}\n", InputValue.Type);
            OutputValue += string.Format("Sizes: {0}x{1}x{2} sm\n", InputValue.Size_X, InputValue.Size_Y, InputValue.Size_Z);
            OutputValue += string.Format("Declared price: {0} UAH\n\n", InputValue.DeclaredPrice);

            OutputValue += string.Format("Delivery price: {0} UAH\n", InputValue.Price);
            OutputValue += string.Format("Status: {0}\n\n", InputValue.Status);

            OutputValue += string.Format("Date clearance : {0}\n", InputValue.DateClearance);
            OutputValue += string.Format("Date receiving: {0}\n\n", InputValue.DateReceiving);

            OutputValue += InputValue.IsPaid ? "Order is paid\n" : "Order is not paid\n";
            OutputValue += InputValue.IsReceived ? "Order is received\n" : "";
            OutputValue += InputValue.IsDenied ? "Order is denied\n" : "";

            return OutputValue;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
