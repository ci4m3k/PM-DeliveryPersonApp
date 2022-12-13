using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryPersonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParcelPage : ContentPage
    {
        public ParcelPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Parcel>();
                var parcels = conn.Table<Parcel>().ToList();

                parcelListView.ItemsSource = parcels;
            }
        }

        private void ParcelListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = parcelListView.SelectedItem as Parcel;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new ParcelDetailPage());
            }
        }
    }
}