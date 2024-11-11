using MVVMTutorial.Model;
using MVVMTutorial.MVVM;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMTutorial.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => selectedItem != null);

        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => selectedItem != null);

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item
            {
                Name = "Product1",
                SerialNumber = "0001",
                Quantity = 5
            });
            Items.Add(new Item
            {
                Name = "Product2",
                SerialNumber = "0002",
                Quantity=6
            });

        }

        private Item selectedItem;
        public Item SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name="NEW ITEM",
                SerialNumber="XXXXX",
                Quantity=0
            });
        }
        private void DeleteItem()
        {
            Items.Remove(selectedItem);
        }
        private void Save()
        {
            //save to db
        }
        private bool CanSave()
        {
            return true;
        }

    }
}
