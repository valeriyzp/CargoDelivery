using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace CargoDelivery.Model
{
    public class User : DBLoader, INotifyPropertyChanged, IDataErrorInfo
    {
        private int iD = -1;
        private string username = "";
        private string password = "";

        public int ID
        {
            get { return iD; }
            set
            {
                if (iD != value)
                {
                    iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                if(username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public bool isLoginAsUser()
        {
            if (isLoginAsUser(Username, Password)) return true;
            else return false;
        }

        public bool isLoginAsAdmin()
        {
            if (isLoginAsAdmin(Username, Password)) return true;
            else return false;
        }

        public Consumer getConsumer()
        {
            return getConsumerByUsername(Username);
        }

        public Operator getOperator()
        {
            return new Operator(Username);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        #region IDataErrorInfo Validation

        static readonly string[] ValidatedProperties =
{
            "Username", "Password"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Username":
                    {
                        error = ValidateUsername();
                        break;
                    }
                case "Password":
                    {
                        error = ValidatePassword();
                        break;
                    }
            }
            return error;
        }

        public string ValidateUsername()
        {
            if(Regex.IsMatch(Username, @"[^A-z0-9_]"))
            {
                return "Invalid data";
            }
            else if (Username.Count() < 3)
            {
                return "Must be at least 3 characters";
            }
            else if (Username.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        public string ValidatePassword()
        {
            if (Regex.IsMatch(Password, @"[^A-z0-9]"))
            {
                return "Invalid data";
            }
            else if (Password.Count() < 3)
            {
                return "Must be at least 3 characters";
            }
            if (Password.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        #endregion
    }

    public class Consumer : User, IDataErrorInfo
    {
        private string email = "";
        public string firstName = "";
        public string lastName = "";
        public string phoneNumber = "";

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public Consumer(int iD, string username, string email, string firstName, string secondName, string phoneNumber)
        {
            ID = iD;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = secondName;
            PhoneNumber = phoneNumber;
        }

        public Consumer() { ;}

        public bool registerNewConsumer()
        {
            return registerNewConsumer(Username, Password, Email, FirstName, LastName, PhoneNumber);
        }

        public bool updateConsumerInfo()
        {
            return updateConsumerByID(ID, FirstName, LastName);
        }

        public Consumer getConsumerInfo()
        {
            return getConsumerByID(ID);
        }

        public ObservableCollection<Order> getOrders()
        {
            return getOrdersByPhoneNumber(PhoneNumber);
        }

        public bool addOrder(Order NewOrder)
        {
            return addNewOrder(NewOrder);
        }

        public bool cancelOrder(int id)
        {
            return cancelOrderByID(id);
        }

        new public Order getOrderByNumber(string number)
        {
            return getOrderByNumberAndConsumerPhoneNumber(number, PhoneNumber);
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        #region IDataErrorInfo Validation

        static readonly string[] ValidatedProperties =
        {
            "Username", "Password", "Email", "FirstName", "LastName", "PhoneNumber"
        };

        public new bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedPropertiesAccountChangeInfo =
        {
            "Username", "Email", "FirstName", "LastName", "PhoneNumber"
        };

        public bool IsValidAccountChangeInfo
        {
            get
            {
                foreach (string property in ValidatedPropertiesAccountChangeInfo)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Username":
                    error = ValidateUsername();
                    break;
                case "Password":
                    error = ValidatePassword();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;
                case "FirstName":
                    error = ValidateFirstName();
                    break;
                case "LastName":
                    error = ValidateLastName();
                    break;
                case "PhoneNumber":
                    error = ValidatePhoneNumber();
                    break;
            }
            return error;
        }

        private string ValidateEmail()
        {
            if (Email.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if (!Regex.IsMatch(Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
            {
                return "Invalid data";
            }
            else if(Email.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        private string ValidateFirstName()
        {
            if (FirstName.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if (FirstName.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        private string ValidateLastName()
        {
            if (LastName.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if (LastName.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        private string ValidatePhoneNumber()
        {
            if (PhoneNumber.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if(!Regex.IsMatch(PhoneNumber, @"^[0]{1}[0-9]{9}$"))
            {
                return "Invalid data";
            }
            return null;
        }

        #endregion
    }

    public class Operator : User
    {
        public Operator(string username)
        {
            Username = username;
        }

        public bool addOrder(Order NewOrder)
        {
            return addNewOrder(NewOrder);
        }

        public bool updateOrder(Order order)
        {
            return updateNewOrder(order);
        }

        public bool payForOrder(int id)
        {
            return payForOrderByID(id);
        }

        public bool receiveOrder(int id)
        {
            return receiveOrderByID(id);
        }

        public Order getOrderByOrderNumber(string number)
        {
            return getOrderByNumber(number);
        }

        // Unused, but useful
        public List<Truck> getTrucksForOrder(int id)
        {
            return getTrucksForOrderByOrderID(id);
        }

        // Unused, but useful
        public bool addTruckToOrder(int truckID, int OrderID)
        {
            return addTruckToOrderByID(truckID, OrderID);
        }

        public bool setTruckArrival(string truckID)
        {
            return TruckArrival(truckID);
        }

        public bool addOrderToTruckByTruckIdAndNumber(string truckID, string orderNumber)
        {
            return addOrderToTruck(truckID, orderNumber);
        }
    }

    public class Truck : INotifyPropertyChanged
    {
        private int iD = -1;
        private string name = "";
        private string departure = "";
        private string destination = "";
        private int spaciousness = 0;
        private string dateDeparture = "";
        private string dateArrival = "";
        private bool isDone = false;

        public int ID
        {
            get { return iD; }
            set
            {
                if (iD != value)
                {
                    iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Departure
        {
            get { return departure; }
            set
            {
                if (departure != value)
                {
                    departure = value;
                    OnPropertyChanged("Departure");
                }
            }
        }
        public string Destination
        {
            get { return destination; }
            set
            {
                if (destination != value)
                {
                    destination = value;
                    OnPropertyChanged("Destination");
                }
            }
        }
        public int Spaciousness
        {
            get { return spaciousness; }
            set
            {
                if (spaciousness != value)
                {
                    spaciousness = value;
                    OnPropertyChanged("Spaciousness");
                }
            }
        }
        public string DateDeparture
        {
            get { return dateDeparture; }
            set
            {
                if (dateDeparture != value)
                {
                    dateDeparture = value;
                    OnPropertyChanged("DateDeparture");
                }
            }
        }
        public string DateArrival
        {
            get { return dateArrival; }
            set
            {
                if (dateArrival != value)
                {
                    dateArrival = value;
                    OnPropertyChanged("DateArrival");
                }
            }
        }
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone != value)
                {
                    isDone = value;
                    OnPropertyChanged("IsDone");
                }
            }
        }

        public Truck(int iD, string name, string departure, string destination, int spaciousness, string dateDeparture, string dateArrival, bool isDone)
        {
            ID = iD;
            Name = name;
            Departure = departure;
            Destination = destination;
            Spaciousness = spaciousness;
            DateDeparture = dateDeparture;
            DateArrival = dateArrival;
            IsDone = isDone;
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

    public class Order : INotifyPropertyChanged, IDataErrorInfo
    {
        private int iD = -1;
        private string number = "";
        private string senderFirstName = "";
        private string senderLastName = "";
        private string senderPhoneNumber = "";
        private string senderCity = "";
        private string receiverFirstName = "";
        private string receiverLastName = "";
        private string receiverPhoneNumber = "";
        private string receiverCity = "";
        private string type = "Package";
        private int weight = 0;
        private int size_X = 0;
        private int size_Y = 0;
        private int size_Z = 0;
        private int declaredPrice = 0;
        private int price = 0;
        private string dateClearance = DateTime.Now.ToString("dd.MM.yyyy");
        private string dateReceiving = "";
        private int truck = -1;
        private string status = "";
        private bool isPaid = false;
        private bool isDenied = false;
        private bool isReceived = false;

        public string SenderFirstPlusLastName { get { return SenderFirstName + " " + SenderLastName; } }
        public string ReceiverFirstPlusLastName { get { return ReceiverFirstName + " " + ReceiverLastName; } }
        public int ID
        {
            get { return iD; }
            set
            {
                if (iD != value)
                {
                    iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        public string SenderFirstName
        {
            get { return senderFirstName; }
            set
            {
                if (senderFirstName != value)
                {
                    senderFirstName = value;
                    OnPropertyChanged("SenderFirstName");
                }
            }
        }
        public string SenderLastName
        {
            get { return senderLastName; }
            set
            {
                if (senderLastName != value)
                {
                    senderLastName = value;
                    OnPropertyChanged("SenderLastName");
                }
            }
        }
        public string SenderPhoneNumber
        {
            get { return senderPhoneNumber; }
            set
            {
                if (senderPhoneNumber != value)
                {
                    senderPhoneNumber = value;
                    OnPropertyChanged("SenderPhoneNumber");
                }
            }
        }
        public string SenderCity
        {
            get { return senderCity; }
            set
            {
                if (senderCity != value)
                {
                    senderCity = value;
                    OnPropertyChanged("SenderCity");
                }
            }
        }
        public string ReceiverFirstName
        {
            get { return receiverFirstName; }
            set
            {
                if (receiverFirstName != value)
                {
                    receiverFirstName = value;
                    OnPropertyChanged("ReceiverFirstName");
                }
            }
        }
        public string ReceiverLastName
        {
            get { return receiverLastName; }
            set
            {
                if (receiverLastName != value)
                {
                    receiverLastName = value;
                    OnPropertyChanged("ReceiverLastName");
                }
            }
        }
        public string ReceiverPhoneNumber
        {
            get { return receiverPhoneNumber; }
            set
            {
                if (receiverPhoneNumber != value)
                {
                    receiverPhoneNumber = value;
                    OnPropertyChanged("ReceiverPhoneNumber");
                }
            }
        }
        public string ReceiverCity
        {
            get { return receiverCity; }
            set
            {
                if (receiverCity != value)
                {
                    receiverCity = value;
                    OnPropertyChanged("ReceiverCity");
                }
            }
        }
        public List<String> Types
        {
            get
            {
                return new List<string> { "Package", "Cargo", "Documents", "Tires" };
            }
            set
            {
                ;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                if (weight != value)
                {
                    weight = value;
                    OnPropertyChanged("Weight");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int Size_X
        {
            get { return size_X; }
            set
            {
                if (size_X != value)
                {
                    size_X = value;
                    OnPropertyChanged("Size_X");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int Size_Y
        {
            get { return size_Y; }
            set
            {
                if (size_Y != value)
                {
                    size_Y = value;
                    OnPropertyChanged("Size_Y");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int Size_Z
        {
            get { return size_Z; }
            set
            {
                if (size_Z != value)
                {
                    size_Z = value;
                    OnPropertyChanged("Size_Z");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int DeclaredPrice
        {
            get { return declaredPrice; }
            set
            {
                if (declaredPrice != value)
                {
                    declaredPrice = value;
                    OnPropertyChanged("DeclaredPrice");
                    OnPropertyChanged("PriceForecast");
                }
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public int PriceForecast
        {
            get { return get_price(); }
            set {; }
        }
        public string DateClearance
        {
            get { return dateClearance; }
            set
            {
                if (dateClearance != value)
                {
                    dateClearance = value;
                    OnPropertyChanged("DateClearance");
                }
            }
        }
        public string DateReceiving
        {
            get { return dateReceiving; }
            set
            {
                if (dateReceiving != value)
                {
                    dateReceiving = value;
                    OnPropertyChanged("DateReceiving");
                }
            }
        }
        public int Truck
        {
            get { return truck; }
            set
            {
                if (truck != value)
                {
                    truck = value;
                    OnPropertyChanged("Truck");
                }
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public bool IsPaid
        {
            get { return isPaid; }
            set
            {
                if (isPaid != value)
                {
                    isPaid = value;
                    OnPropertyChanged("isPaid");
                }
            }
        }
        public bool IsDenied
        {
            get { return isDenied; }
            set
            {
                if (isDenied != value)
                {
                    isDenied = value;
                    OnPropertyChanged("IsDenied");
                }
            }
        }
        public bool IsReceived
        {
            get { return isReceived; }
            set
            {
                if (isReceived != value)
                {
                    isReceived = value;
                    OnPropertyChanged("IsReceived");
                }
            }
        }

        public Order(int iD, string number, string senderFirstName, string senderLastName, string senderPhoneNumber, string senderCity,
            string receiverFirstName, string receiverLastName, string receiverPhoneNumber, string receiverCity,
            string type, int weight, int size_X, int size_Y, int size_Z, int declaredPrice, int price, string dateClearance,
            string dateReceiving, int truck, string status, bool isPaid, bool isDenied, bool isReceived)
        {
            ID = iD;
            Number = number;
            SenderFirstName = senderFirstName;
            SenderLastName = senderLastName;
            SenderPhoneNumber = senderPhoneNumber;
            SenderCity = senderCity;
            ReceiverFirstName = receiverFirstName;
            ReceiverLastName = receiverLastName;
            ReceiverPhoneNumber = receiverPhoneNumber;
            ReceiverCity = receiverCity;
            Type = type;
            Weight = weight;
            Size_X = size_X;
            Size_Y = size_Y;
            Size_Z = size_Z;
            DeclaredPrice = declaredPrice;
            Price = price;
            DateClearance = dateClearance;
            DateReceiving = dateReceiving;
            Truck = truck;
            Status = status;
            IsPaid = isPaid;
            IsDenied = isDenied;
            IsReceived = isReceived;
        }

        public Order()
        {
            ;
        }

        public int get_price()
        {
            int ResultPrice = 50 + Convert.ToInt32(DeclaredPrice * 0.01);
            if (Type == "Documents") ResultPrice += 20;
            ResultPrice += (Convert.ToInt32(Size_X * Size_Y * Size_Z * 0.000001) * 10);
            ResultPrice += (Weight * 10);

            return ResultPrice;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        #region IDataErrorInfo Validation

        static readonly string[] ValidatedProperties =
{
            "SenderFirstName", "SenderLastName", "SenderPhoneNumber", "SenderCity",
            "ReceiverFirstName", "ReceiverLastName", "ReceiverPhoneNumber", "ReceiverCity",
            "Weight", "Size_X", "Size_Y", "Size_Z", "DeclaredPrice"

        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "SenderFirstName":
                    {
                        error = ValidateSenderFirstName();
                        break;
                    }
                case "SenderLastName":
                    {
                        error = ValidateSenderLastName();
                        break;
                    }
                case "SenderPhoneNumber":
                    {
                        error = ValidateSenderPhoneNumber();
                        break;
                    }
                case "SenderCity":
                    {
                        error = ValidateSenderCity();
                        break;
                    }
                case "ReceiverFirstName":
                    {
                        error = ValidateReceiverFirstName();
                        break;
                    }
                case "ReceiverLastName":
                    {
                        error = ValidateReceiverLastName();
                        break;
                    }
                case "ReceiverPhoneNumber":
                    {
                        error = ValidateReceiverPhoneNumber();
                        break;
                    }
                case "ReceiverCity":
                    {
                        error = ValidateReceiverCity();
                        break;
                    }
                case "Weight":
                    {
                        error = ValidateWeight();
                        break;
                    }
                case "Size_X":
                    {
                        error = ValidateSize_X();
                        break;
                    }
                case "Size_Y":
                    {
                        error = ValidateSize_Y();
                        break;
                    }
                case "Size_Z":
                    {
                        error = ValidateSize_Z();
                        break;
                    }
                case "DeclaredPrice":
                    {
                        error = ValidateDeclaredPrice();
                        break;
                    }
            }
            return error;
        }

        public string ValidateStringFromLength0_32(string value)
        {
            if (value.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if (value.Count() > 32)
            {
                return "Must be no more than 32 characters";
            }
            return null;
        }

        public string ValidateStringFromPhoneNumber(string value)
        {
            if (value.Count() == 0)
            {
                return "This field cannot be empty";
            }
            else if (!Regex.IsMatch(value, @"^[0]{1}[0-9]{9}$"))
            {
                return "Invalid data";
            }
            return null;
        }

        public string ValidateIntSize(int value)
        {
            if(value <= 0)
            {
                return "Invalid data";
            }
            return null;
        }

        public string ValidateSenderFirstName()
        {
            return ValidateStringFromLength0_32(SenderFirstName);
        }

        public string ValidateSenderLastName()
        {
            return ValidateStringFromLength0_32(SenderLastName);
        }

        public string ValidateSenderPhoneNumber()
        {
            return ValidateStringFromPhoneNumber(SenderPhoneNumber);
        }

        public string ValidateSenderCity()
        {
            return ValidateStringFromLength0_32(SenderCity);
        }

        public string ValidateReceiverFirstName()
        {
            return ValidateStringFromLength0_32(ReceiverFirstName);
        }

        public string ValidateReceiverLastName()
        {
            return ValidateStringFromLength0_32(ReceiverLastName);
        }

        public string ValidateReceiverPhoneNumber()
        {
            return ValidateStringFromPhoneNumber(ReceiverPhoneNumber);
        }

        public string ValidateReceiverCity()
        {
            return ValidateStringFromLength0_32(ReceiverCity);
        }

        public string ValidateWeight()
        {
            return ValidateIntSize(Weight);
        }

        public string ValidateDeclaredPrice()
        {
            return ValidateIntSize(DeclaredPrice);
        }

        public string ValidateSize_X()
        {
            return ValidateIntSize(Size_X);
        }

        public string ValidateSize_Y()
        {
            return ValidateIntSize(Size_Y);
        }

        public string ValidateSize_Z()
        {
            return ValidateIntSize(Size_Z);
        }

        #endregion
    }

    public class DBLoader
    {
        private string connectionString = @"Data Source=DESKTOP-IK3PHF1\SQLEXPRESS;Initial Catalog=CargoDeliveryDB;Integrated Security=SSPI";

        protected bool isLoginAsUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT count(id) FROM [user] WHERE username = @username AND password = @password AND is_admin = 0;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter usernameParam = new SqlParameter("@username", username);
                    SqlParameter passwordParam = new SqlParameter("@password", password);
                    command.Parameters.Add(usernameParam);
                    command.Parameters.Add(passwordParam);

                    if (Convert.ToInt32(command.ExecuteScalar()) > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool isLoginAsAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT count(id) FROM [user] WHERE username = @username AND password = @password AND is_admin = 1;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter usernameParam = new SqlParameter("@username", username);
                    SqlParameter passwordParam = new SqlParameter("@password", password);
                    command.Parameters.Add(usernameParam);
                    command.Parameters.Add(passwordParam);

                    if (Convert.ToInt32(command.ExecuteScalar()) > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected Consumer getConsumerByUsername(string username)
        {
            Consumer Temp = new Consumer();
            Temp.Username = username;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT id, email, first_name, last_name, phone_number FROM [user] WHERE username = @username;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter usernameParam = new SqlParameter("@username", username);
                    command.Parameters.Add(usernameParam);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Temp.ID = Convert.ToInt32(reader["id"]);
                    Temp.Email = Convert.ToString(reader["email"]).Trim();
                    Temp.FirstName = Convert.ToString(reader["first_name"]).Trim();
                    Temp.LastName = Convert.ToString(reader["last_name"]).Trim();
                    Temp.PhoneNumber = Convert.ToString(reader["phone_number"]).Trim();
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return Temp;
        }

        protected Consumer getConsumerByID(int id)
        {
            Consumer Temp = new Consumer();
            Temp.ID = id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT id, username, email, first_name, last_name, phone_number FROM [user] WHERE id = @id;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter IDParam = new SqlParameter("@id", id);
                    command.Parameters.Add(IDParam);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Temp.ID = Convert.ToInt32(reader["id"]);
                    Temp.Username = Convert.ToString(reader["username"]).Trim();
                    Temp.Email = Convert.ToString(reader["email"]).Trim();
                    Temp.FirstName = Convert.ToString(reader["first_name"]).Trim();
                    Temp.LastName = Convert.ToString(reader["last_name"]).Trim();
                    Temp.PhoneNumber = Convert.ToString(reader["phone_number"]).Trim();
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return Temp;
        }

        protected bool registerNewConsumer(string username, string password, string email, string first_name, string last_name, string phone_number)
        {
            if (username.Count() == 0 || password.Count() == 0 || email.Count() == 0 || first_name.Count() == 0 || last_name.Count() == 0 || phone_number.Count() == 0) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT COUNT(id) FROM [user] WHERE username = @username OR email = @email OR phone_number = @phone_number;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter usernameParam = new SqlParameter("@username", username);
                    SqlParameter emailParam = new SqlParameter("@email", email);
                    SqlParameter phone_numberParam = new SqlParameter("@phone_number", phone_number);
                    command.Parameters.Add(usernameParam);
                    command.Parameters.Add(emailParam);
                    command.Parameters.Add(phone_numberParam);

                    if (Convert.ToInt32(command.ExecuteScalar()) > 0) return false;

                    sqlExpression = string.Format("INSERT INTO [user] (username, password, email, first_name, last_name, phone_number, is_admin) VALUES (@username, @password, @email, @first_name, @last_name, @phone_number, 0)");
                    command = new SqlCommand(sqlExpression, connection);
                    usernameParam = new SqlParameter("@username", username);
                    emailParam = new SqlParameter("@email", email);
                    phone_numberParam = new SqlParameter("@phone_number", phone_number);
                    SqlParameter passwordParam = new SqlParameter("@password", password);
                    SqlParameter first_nameParam = new SqlParameter("@first_name", first_name);
                    SqlParameter last_nameParam = new SqlParameter("@last_name", last_name);
                    command.Parameters.Add(usernameParam);
                    command.Parameters.Add(emailParam);
                    command.Parameters.Add(phone_numberParam);
                    command.Parameters.Add(passwordParam);
                    command.Parameters.Add(first_nameParam);
                    command.Parameters.Add(last_nameParam);

                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool updateConsumerByID(int id, string first_name, string last_name)
        {
            if (id < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("UPDATE [user] SET first_name = @first_name, last_name = @last_name WHERE id = @id;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter iDParam = new SqlParameter("@id", id);
                    SqlParameter firstNameParam = new SqlParameter("@first_name", first_name);
                    SqlParameter lastNameParam = new SqlParameter("@last_name", last_name);
                    command.Parameters.Add(iDParam);
                    command.Parameters.Add(firstNameParam);
                    command.Parameters.Add(lastNameParam);

                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected Order getOrderByNumberAndConsumerPhoneNumber(string number, string phone_number)
        {
            Order order = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT * FROM [order] WHERE number = @number AND (sender_phone_number = @phone_number OR receiver_phone_number = @phone_number);");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter phoneNumberParam = new SqlParameter("@phone_number", phone_number);
                    SqlParameter numberParam = new SqlParameter("@number", number);
                    command.Parameters.Add(phoneNumberParam);
                    command.Parameters.Add(numberParam);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        order = new Order(Convert.ToInt32(reader["id"]), Convert.ToString(reader["number"]).Trim(),
                            Convert.ToString(reader["sender_first_name"]).Trim(), Convert.ToString(reader["sender_last_name"]).Trim(),
                            Convert.ToString(reader["sender_phone_number"]).Trim(), Convert.ToString(reader["sender_city"]).Trim(),
                            Convert.ToString(reader["receiver_first_name"]).Trim(), Convert.ToString(reader["receiver_last_name"]).Trim(),
                            Convert.ToString(reader["receiver_phone_number"]).Trim(), Convert.ToString(reader["receiver_city"]).Trim(),
                            Convert.ToString(reader["type"]).Trim(), Convert.ToInt32(reader["weight"]),
                            Convert.ToInt32(reader["size_x"]), Convert.ToInt32(reader["size_y"]), Convert.ToInt32(reader["size_z"]),
                            Convert.ToInt32(reader["declared_price"]), Convert.ToInt32(reader["price"]),
                            Convert.ToString(reader["date_clearance"]).Trim().Replace(" 00:00:00", ""), Convert.ToString(reader["date_receiving"] == System.DBNull.Value ? "" : reader["date_receiving"]).Trim().Replace(" 00:00:00", ""),
                            Convert.ToInt32(reader["truck"] == System.DBNull.Value ? -1 : reader["truck"]), Convert.ToString(reader["status"]).Trim(),
                            Convert.ToBoolean(reader["is_paid"]), Convert.ToBoolean(reader["is_denied"]), Convert.ToBoolean(reader["is_received"]));
                    }
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return order;
        }

        protected Order getOrderByNumber(string number)
        {
            Order order = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT * FROM [order] WHERE number = @number;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter numberParam = new SqlParameter("@number", number);
                    command.Parameters.Add(numberParam);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        order = new Order(Convert.ToInt32(reader["id"]), Convert.ToString(reader["number"]).Trim(),
                            Convert.ToString(reader["sender_first_name"]).Trim(), Convert.ToString(reader["sender_last_name"]).Trim(),
                            Convert.ToString(reader["sender_phone_number"]).Trim(), Convert.ToString(reader["sender_city"]).Trim(),
                            Convert.ToString(reader["receiver_first_name"]).Trim(), Convert.ToString(reader["receiver_last_name"]).Trim(),
                            Convert.ToString(reader["receiver_phone_number"]).Trim(), Convert.ToString(reader["receiver_city"]).Trim(),
                            Convert.ToString(reader["type"]).Trim(), Convert.ToInt32(reader["weight"]),
                            Convert.ToInt32(reader["size_x"]), Convert.ToInt32(reader["size_y"]), Convert.ToInt32(reader["size_z"]),
                            Convert.ToInt32(reader["declared_price"]), Convert.ToInt32(reader["price"]),
                            Convert.ToString(reader["date_clearance"]).Trim().Replace(" 00:00:00", ""), Convert.ToString(reader["date_receiving"] == System.DBNull.Value ? "" : reader["date_receiving"]).Trim().Replace(" 00:00:00", ""),
                            Convert.ToInt32(reader["truck"] == System.DBNull.Value ? -1 : reader["truck"]), Convert.ToString(reader["status"]).Trim(),
                            Convert.ToBoolean(reader["is_paid"]), Convert.ToBoolean(reader["is_denied"]), Convert.ToBoolean(reader["is_received"]));
                    }
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return order;
        }

        protected ObservableCollection<Order> getOrdersByPhoneNumber(string phone_number)
        {
            ObservableCollection<Order> Orders = new ObservableCollection<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT * FROM [order] WHERE sender_phone_number = @phone_number OR receiver_phone_number = @phone_number;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter phoneNumberParam = new SqlParameter("@phone_number", phone_number);
                    command.Parameters.Add(phoneNumberParam);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order NewOrder = new Order(Convert.ToInt32(reader["id"]), Convert.ToString(reader["number"]).Trim(),
                            Convert.ToString(reader["sender_first_name"]).Trim(), Convert.ToString(reader["sender_last_name"]).Trim(),
                            Convert.ToString(reader["sender_phone_number"]).Trim(), Convert.ToString(reader["sender_city"]).Trim(),
                            Convert.ToString(reader["receiver_first_name"]).Trim(), Convert.ToString(reader["receiver_last_name"]).Trim(),
                            Convert.ToString(reader["receiver_phone_number"]).Trim(), Convert.ToString(reader["receiver_city"]).Trim(),
                            Convert.ToString(reader["type"]).Trim(), Convert.ToInt32(reader["weight"]),
                            Convert.ToInt32(reader["size_x"]), Convert.ToInt32(reader["size_y"]), Convert.ToInt32(reader["size_z"]),
                            Convert.ToInt32(reader["declared_price"]), Convert.ToInt32(reader["price"]),
                            Convert.ToString(reader["date_clearance"]).Trim().Replace(" 00:00:00", ""), Convert.ToString(reader["date_receiving"] == System.DBNull.Value ? "" : reader["date_receiving"]).Trim().Replace(" 00:00:00", ""),
                            Convert.ToInt32(reader["truck"] == System.DBNull.Value ? -1 : reader["truck"]), Convert.ToString(reader["status"]).Trim(),
                            Convert.ToBoolean(reader["is_paid"]), Convert.ToBoolean(reader["is_denied"]), Convert.ToBoolean(reader["is_received"]));
                        Orders.Add(NewOrder);
                    }
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return Orders;
        }

        protected bool addNewOrder(Order NewOrder)
        {
            string date_clearance = DateTime.Now.ToString("yyyyMMdd");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT IDENT_CURRENT('order');");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    string number = (Convert.ToInt32(command.ExecuteScalar()) + 1).ToString("2000000000000");
                    
                    sqlExpression = string.Format("INSERT INTO [order] (number, sender_first_name, sender_last_name, sender_phone_number, sender_city, " +
                        "receiver_first_name, receiver_last_name, receiver_phone_number, receiver_city, type, weight, size_x, size_y, size_z, " +
                        "declared_price, price, date_clearance, status, is_paid, is_denied, is_received) " +
                        "VALUES (@number, @sender_first_name, @sender_last_name, @sender_phone_number, @sender_city, " +
                        "@receiver_first_name, @receiver_last_name, @receiver_phone_number, @receiver_city, @type, @weight, @size_x, @size_y, @size_z, " +
                        "@declared_price, @price, @date_clearance, @status, 0, 0, 0)");
                    
                    command.CommandText = sqlExpression;
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@sender_first_name", NewOrder.SenderFirstName);
                    command.Parameters.AddWithValue("@sender_last_name", NewOrder.SenderLastName);
                    command.Parameters.AddWithValue("@sender_phone_number", NewOrder.SenderPhoneNumber);
                    command.Parameters.AddWithValue("@sender_city", NewOrder.SenderCity);
                    command.Parameters.AddWithValue("@receiver_first_name", NewOrder.ReceiverFirstName);
                    command.Parameters.AddWithValue("@receiver_last_name", NewOrder.ReceiverLastName);
                    command.Parameters.AddWithValue("@receiver_phone_number", NewOrder.ReceiverPhoneNumber);
                    command.Parameters.AddWithValue("@receiver_city", NewOrder.ReceiverCity);
                    command.Parameters.AddWithValue("@type", NewOrder.Type);
                    command.Parameters.AddWithValue("@weight", NewOrder.Weight);
                    command.Parameters.AddWithValue("@size_x", NewOrder.Size_X);
                    command.Parameters.AddWithValue("@size_y", NewOrder.Size_Y);
                    command.Parameters.AddWithValue("@size_z", NewOrder.Size_Z);
                    command.Parameters.AddWithValue("@declared_price", NewOrder.DeclaredPrice);
                    command.Parameters.AddWithValue("@price", NewOrder.get_price());
                    command.Parameters.AddWithValue("@date_clearance", date_clearance);
                    command.Parameters.AddWithValue("@status", "Accepted");
                    
                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool updateNewOrder(Order NewOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("UPDATE [order] SET sender_first_name = @sender_first_name, sender_last_name = @sender_last_name, " +
                        "sender_phone_number = @sender_phone_number, sender_city = @sender_city, " +
                        "receiver_first_name = @receiver_first_name, receiver_last_name = @receiver_last_name, " +
                        "receiver_phone_number = @receiver_phone_number, receiver_city = @receiver_city, " +
                        "type = @type, weight = @weight, size_x = @size_x, size_y = @size_y, size_z = @size_z, declared_price = @declared_price, price = @price " +
                        "WHERE id = @id;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandText = sqlExpression;
                    command.Parameters.AddWithValue("@id", NewOrder.ID);
                    command.Parameters.AddWithValue("@sender_first_name", NewOrder.SenderFirstName);
                    command.Parameters.AddWithValue("@sender_last_name", NewOrder.SenderLastName);
                    command.Parameters.AddWithValue("@sender_phone_number", NewOrder.SenderPhoneNumber);
                    command.Parameters.AddWithValue("@sender_city", NewOrder.SenderCity);
                    command.Parameters.AddWithValue("@receiver_first_name", NewOrder.ReceiverFirstName);
                    command.Parameters.AddWithValue("@receiver_last_name", NewOrder.ReceiverLastName);
                    command.Parameters.AddWithValue("@receiver_phone_number", NewOrder.ReceiverPhoneNumber);
                    command.Parameters.AddWithValue("@receiver_city", NewOrder.ReceiverCity);
                    command.Parameters.AddWithValue("@type", NewOrder.Type);
                    command.Parameters.AddWithValue("@weight", NewOrder.Weight);
                    command.Parameters.AddWithValue("@size_x", NewOrder.Size_X);
                    command.Parameters.AddWithValue("@size_y", NewOrder.Size_Y);
                    command.Parameters.AddWithValue("@size_z", NewOrder.Size_Z);
                    command.Parameters.AddWithValue("@declared_price", NewOrder.DeclaredPrice);
                    command.Parameters.AddWithValue("@price", NewOrder.get_price());
                    
                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool cancelOrderByID(int id)
        {
            if (id < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("Update [order] SET is_denied = 1, is_paid = 0 WHERE id = @id AND is_received = 0;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter iDParam = new SqlParameter("@id", id);
                    command.Parameters.Add(iDParam);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        return updateOrderStatusByID(id, "Canceled");
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool payForOrderByID(int id)
        {
            if (id < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("Update [order] SET is_paid = 1 WHERE id = @id AND is_received = 0 AND is_denied = 0;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter iDParam = new SqlParameter("@id", id);
                    command.Parameters.Add(iDParam);

                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool receiveOrderByID(int id)
        {
            if (id < 1) return false;
            string date_receiving = DateTime.Now.ToString("yyyyMMdd");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("Update [order] SET date_receiving = @date_receiving, is_received = 1 WHERE id = @id AND is_denied = 0 AND is_paid = 1;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter iDParam = new SqlParameter("@id", id);
                    SqlParameter DateReceivingParam = new SqlParameter("@date_receiving", date_receiving);
                    command.Parameters.Add(iDParam);
                    command.Parameters.Add(DateReceivingParam);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        return updateOrderStatusByID(id, "Completed");
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool updateOrderStatusByID(int id, string status)
        {
            if (id < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("Update [order] SET status = @status WHERE id = @id;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", id);

                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        // Unused, but useful
        protected List<Truck> getTrucksForOrderByOrderID(int id)
        {
            List<Truck> Trucks = new List<Truck>();
            string departure = "", destination = "", date_clearance = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();
                    string sqlExpression = string.Format("SELECT sender_city, receiver_city, date_clearance FROM [order] WHERE id = @id;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter iDParam = new SqlParameter("@id", id);
                    command.Parameters.Add(iDParam);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        departure = Convert.ToString(reader["sender_city"]).Trim();
                        destination = Convert.ToString(reader["receiver_city"]).Trim();
                        date_clearance = Convert.ToString(reader["date_clearance"]).Trim();
                    }
                    reader.Close();
                    
                    sqlExpression = string.Format("SELECT * FROM [truck] WHERE departure = @departure AND destination = @destination AND date_departure >= @date_departure;");
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@departure", departure);
                    command.Parameters.AddWithValue("@destination", destination);
                    command.Parameters.AddWithValue("@date_departure", date_clearance);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Truck NewTruck = new Truck(Convert.ToInt32(reader["id"]), Convert.ToString(reader["name"]).Trim(),
                            departure, destination, Convert.ToInt32(reader["spaciousness"]), Convert.ToString(reader["date_departure"]).Trim(),
                            Convert.ToString(reader["date_arrival"]).Trim(), Convert.ToBoolean(reader["is_done"]));
                        Trucks.Add(NewTruck);
                    }
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return Trucks;
        }

        // Unused, but useful
        protected bool addTruckToOrderByID(int truckID, int OrderID)
        {
            if (truckID < 1) return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  
                    string sqlExpression = string.Format("Update [order] SET truck = @truck WHERE id = @id AND truck is null;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@truck", truckID);
                    command.Parameters.AddWithValue("@id", OrderID);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        return updateOrderStatusByID(OrderID, "On the way");
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        protected bool addOrderToTruck(string truckID, string orderNumber)
        {
            string departure = "", destination = "", date_departure = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("SELECT departure, destination, date_departure FROM [truck] WHERE id = @truckID AND is_done = 0;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter truckIDParam = new SqlParameter("@truckID", truckID);
                    command.Parameters.Add(truckIDParam);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        departure = Convert.ToString(reader["departure"]).Trim();
                        destination = Convert.ToString(reader["destination"]).Trim();
                        date_departure = Convert.ToDateTime(reader["date_departure"]).ToString("yyyyMMdd");
                    }
                    reader.Close();

                    sqlExpression = string.Format("Update [order] SET truck = @truckID, status = 'On the way' WHERE sender_city = @departure AND receiver_city = @destination AND truck is null AND date_clearance <= @date_departure AND number = @orderNumber AND is_denied = 0;");
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@truckID", truckID);
                    command.Parameters.AddWithValue("@departure", departure);
                    command.Parameters.AddWithValue("@destination", destination);
                    command.Parameters.AddWithValue("@date_departure", date_departure);
                    command.Parameters.AddWithValue("@orderNumber", orderNumber);
                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            return false;
        }

        protected bool TruckArrival(string truckID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlExpression = string.Format("Update [truck] SET is_done = 1 WHERE id = @truckID AND is_done = 0;");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@truckID", truckID);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        try
                        {
                            sqlExpression = string.Format("Update [order] SET status = 'Delivered' WHERE truck = @truckID AND is_denied = 0;");
                            command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@truckID", truckID);

                            command.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    else return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

/*
Cargo types:

Package
Cargo
Documents
Tires
 */

/*
Order status:

Accepted
On the way
Delivered
Completed
Canceled
*/

// Made special for Valeriy Liovkin by Valeriy Kozlov
