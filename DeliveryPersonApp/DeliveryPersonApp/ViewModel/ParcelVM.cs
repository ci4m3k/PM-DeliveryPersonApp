using DeliveryPersonApp.Model;
using DeliveryPersonApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DeliveryPersonApp.ViewModel
{
    public class ParcelVM
    {
        public ObservableCollection<Parcel> Parcels { get; set; }

        private Parcel selectedParcel;
        public Parcel SelectedParcel 
        {
            get { return selectedParcel; }
            set 
            {
                selectedParcel = value;
                if (selectedParcel != null)
                    App.Current.MainPage.Navigation.PushAsync(new ParcelDetailPage(selectedParcel));
            }
        }

        public ParcelVM()
        {
            Parcels = new ObservableCollection<Parcel>();
        }

        public void GetParcels()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                Parcels.Clear();

                conn.CreateTable<Parcel>();
                var parcels = conn.Table<Parcel>().ToList();

                foreach(var parcel in parcels)
                {
                    Parcels.Add(parcel);
                }
            }
        }
    }
}
