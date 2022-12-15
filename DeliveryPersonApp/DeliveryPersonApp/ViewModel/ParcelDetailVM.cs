using DeliveryPersonApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliveryPersonApp.ViewModel
{
    public class ParcelDetailVM : INotifyPropertyChanged
    {
        private Parcel selectedParcel;
        public Parcel SelectedParcel 
        {
            get { return selectedParcel; }
            set
            {
                selectedParcel = value;
                OnPropertyChanged("SelectedParcel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ParcelDetailVM() 
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
