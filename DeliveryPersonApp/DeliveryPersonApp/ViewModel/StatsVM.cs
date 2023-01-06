using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private int activeParcelCount;
        public int ActiveParcelCount
        {
            get { return activeParcelCount; }
            set
            {
                activeParcelCount = value;
                OnPropertyChanged("ActiveParcelCount");
            }
        }

        private int deliveredParcelCount;
        public int DeliveredParcelCount
        {
            get { return deliveredParcelCount; }
            set
            {
                deliveredParcelCount = value;
                OnPropertyChanged("DeliveredParcelCount");
            }
        }

        private int rejectedParcelCount;
        public int RejectedParcelCount
        {
            get { return rejectedParcelCount; }
            set
            {
                rejectedParcelCount = value;
                OnPropertyChanged("RejectedParcelCount");
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
                conn.CreateTable<Parcel>();
                var parcels = conn.Table<Parcel>().ToList();

                ParcelCount = parcels.Count();

                ActiveParcelCount = (from p in parcels
                                     where p.Status == "w realizacji"
                                     select p).Count();

                DeliveredParcelCount = (from p in parcels
                                     where p.Status == "zrealizowane"
                                     select p).Count();

                RejectedParcelCount = (from p in parcels
                                     where p.Status == "odrzucone"
                                     select p).Count();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
