using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DeliveryPersonApp.ViewModel
{
    public class StatsVM : INotifyPropertyChanged
    {
        private int parcelCount;
        public int ParcelCount
        {
            get { return parcelCount; }
            set
            {
                parcelCount = value;
                OnPropertyChanged("ParcelCount");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public StatsVM()
        {
        }

        public void GetParcels()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var parcels = conn.Table<Parcel>();

                ParcelCount = 6;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
