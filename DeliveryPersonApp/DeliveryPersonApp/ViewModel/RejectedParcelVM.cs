using DeliveryPersonApp.Model;
using DeliveryPersonApp.Views;
using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeliveryPersonApp.ViewModel
{
    public class RejectedParcelVM
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

        public RejectedParcelVM()
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

                var rejectedParcels = (from p in parcels
                                       where p.Status == "odrzucone"
                                       select p).ToList();

                foreach (var parcel in rejectedParcels)
                {
                    Parcels.Add(parcel);
                }
            }
        }
    }
}
