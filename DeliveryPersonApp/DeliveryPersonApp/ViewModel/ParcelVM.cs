using DeliveryPersonApp.Model;
using DeliveryPersonApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
            List<Parcel> parcelsList = new List<Parcel>()
            {
                new Parcel()
                {
                    Name = "Przesyłka 1",
                    Number = "111111",
                    Description= "Opis",
                    Weight = 40.2,
                    Size = "200 x 400 mm",
                    City = "Nowy Sącz",
                    Address = "Browarna 34/3",
                    Latitude = 49.612476570865255,
                    Longitude = 20.721617378648331,
                    Status = "zrealizowane",
                },
                new Parcel()
                {
                    Name = "Przesyłka 2",
                    Number = "222222",
                    Description= "Opis",
                    Weight = 25.2,
                    Size = "100 x 230 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Nawojowska 9",
                    Latitude = 49.61340327691061,
                    Longitude = 20.70643555703936,
                    Status = "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 3",
                    Number = "333333",
                    Description= "Opis",
                    Weight = 10.3,
                    Size = "150 x 120 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Barska 23/4",
                    Latitude = 49.62646532876906,
                    Longitude = 20.706143140581915,
                    Status = "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 4",
                    Number = "444444",
                    Description= "Opis",
                    Weight = 15.6,
                    Size = "600 x 423 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Zamenhoffa 1a",
                    Latitude = 49.609108676033465,
                    Longitude = 20.704082592259013,
                    Status = "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 5",
                    Number = "555555",
                    Description= "Opis",
                    Weight = 8.4,
                    Size = "150 x 150 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Staszica 1",
                    Latitude = 49.61703988165713,
                    Longitude = 20.695922798252006,
                    Status = "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 6",
                    Number = "666666",
                    Description= "Opis",
                    Weight = 30.2,
                    Size = "600 x 800 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Radziecka 19",
                    Latitude = 49.60714475503396,
                    Longitude = 20.68745365323497,
                    Status = "odrzucone",
                }
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                Parcels.Clear();

                conn.CreateTable<Parcel>();
                conn.DeleteAll<Parcel>();
                
                foreach(var parcel in parcelsList) 
                {
                    conn.Insert(parcel);
                }

                var parcels = conn.Table<Parcel>().ToList();

                var activeParcels = (from p in parcels
                                     where p.Status == "w realizacji"
                                     select p);

                foreach(var parcel in activeParcels)
                {
                    Parcels.Add(parcel);
                }
            }
        }
    }
}
