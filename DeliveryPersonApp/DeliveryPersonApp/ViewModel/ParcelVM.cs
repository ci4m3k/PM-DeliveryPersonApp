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
                    Address = "ul. Zamenhoffa 1",
                    Status= "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 2",
                    Number = "222222",
                    Description= "Opis",
                    Weight = 25.2,
                    Size = "100 x 230 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Królowej Jadwisko 34/1",
                    Status= "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 3",
                    Number = "333333",
                    Description= "Opis",
                    Weight = 10.3,
                    Size = "150 x 120 mm",
                    City = "Nowy Sącz",
                    Address = "ul. Browarna 23/4",
                    Status= "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 4",
                    Number = "444444",
                    Description= "Opis",
                    Weight = 15.6,
                    Size = "600 x 423 mm",
                    City = "Kraków",
                    Address = "ul. Gabrieli Zapolskiej 21A/39",
                    Status= "w realizacji",
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
                    Status= "w realizacji",
                },
                new Parcel()
                {
                    Name = "Przesyłka 6",
                    Number = "666666",
                    Description= "Opis",
                    Weight = 30.2,
                    Size = "600 x 800 mm",
                    City = "Kraków",
                    Address = "ul. Warszawska 49/2",
                    Status= "w realizacji",
                }
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                Parcels.Clear();

                conn.CreateTable<Parcel>();
                var parcels = conn.Table<Parcel>().ToList();

                if (parcels.Count == 0 )
                {
                    foreach(var parcel in parcelsList) 
                    {
                        parcels.Add(parcel);
                    }
                }

                foreach(var parcel in parcels)
                {
                    Parcels.Add(parcel);
                }
            }
        }
    }
}
