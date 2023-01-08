using DeliveryPersonApp.Model;
using DeliveryPersonApp.Views;
using Plugin.Media.Abstractions;
using Plugin.Media;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DeliveryPersonApp.ViewModel
{
    public class ParcelDetailVM : INotifyPropertyChanged
    {
        public Command DeliverParcelCommand { get; set; }

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

        private bool parcelIsReady;
        public bool ParcelIsReady
        {
            get { return true; }
        }

        public Page CurrentPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ParcelDetailVM() 
        {
            DeliverParcelCommand = new Command<bool>(Deliver, CanDeliver);
        }

        private void Deliver(bool parameter)
        {
            SelectedParcel.Status = "zrealizowane";

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Parcel>();
                conn.Update(SelectedParcel);
            }

            App.Current.MainPage.Navigation.RemovePage(CurrentPage);
        }

        private bool CanDeliver(bool parameter)
        {
            return parameter;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
