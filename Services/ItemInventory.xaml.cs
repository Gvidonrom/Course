using Course.Models;
using System;
using System.ComponentModel;
using System.Windows;

namespace Course.Services
{
  
    public partial class ItemInventory : INotifyPropertyChanged
    {
       
        private readonly string PATH = $"{Environment.CurrentDirectory}\\itemInventoryList.json";
        private BindingList<ItemInventory> _itemInventoryList;
        private FileIOService _fileIOService;

        private string _id;
        private string _equipmentType;
        private string _manufacturer;
        private string _model;
        //private InventoryStatus _status;
        private string _date_of_commissioning;
        private string _serial_number;
        private string _inventory_number;
        private string _city;
        private string _location;
        private string _department;
        private string _full_name;
        private string _notes;

        
        public ItemInventory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);
                    
            try
            {
                _itemInventoryList = _fileIOService.LoadData();
                if (_itemInventoryList == null)
                {
                    _itemInventoryList = new BindingList<ItemInventory>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        

           dgItemInventory.ItemsSource = _itemInventoryList;
           _itemInventoryList.ListChanged += _itemInventoryList_ListChanged;
        }

        private void _itemInventoryList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string EquipmentType
        {
            get { return _equipmentType; }
            set
            {
                if (_equipmentType == value)
                    return;
                _equipmentType = value;
                OnPropertyChanged("EquipmentType");
            }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (_manufacturer == value)
                    return;
                _manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (_model == value)
                    return;
                _model = value;
                OnPropertyChanged("Model");
            }
        }

       /* public InventoryStatus Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;
                _status = value;
                OnPropertyChanged("Статус");
            }
        }*/

        public string Date_of_commissioning
        {
            get { return _date_of_commissioning; }
            set
            {
                if (_date_of_commissioning == value)
                    return;
                _date_of_commissioning = value;
                OnPropertyChanged("Date_of_commissioning");
            }
        }

        public string Serial_number
        {
            get { return _serial_number; }
            set
            {
                if (_serial_number == value)
                    return;
                _serial_number = value;
                OnPropertyChanged("Serial_number");
            }
        }

        public string Inventory_number
        {
            get { return _inventory_number; }
            set
            {
                if (_inventory_number == value)
                    return;
                _inventory_number = value;
                OnPropertyChanged("Inventory_number");
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                    return;
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public string Department
        {
            get { return _department; }
            set
            {
                if (_department == value)
                    return;
                _department = value;
                OnPropertyChanged("Department");
            }
        }

        public string Full_Name
        {
            get { return _full_name; }
            set
            {
                if (_full_name == value)
                    return;
                _full_name = value;
                OnPropertyChanged("Full_Name");
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes == value)
                    return;
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //проверка на нуль
        }

        private void dgItemInventory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}

