using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryPersonApp.NavPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempAddParcelPage : ContentPage
    {
        public TempAddParcelPage()
        {
            InitializeComponent();
        }

        private void AddParcelButton_Clicked(object sender, EventArgs e)
        {
            Parcel parcel = new Parcel()
            {
                Number = numberEntry.Text,
                Description = descriptionEntry.Text,
                Status = statusEntry.Text,
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Parcel>();
                int rows = conn.Insert(parcel);

                if (rows > 0)
                    DisplayAlert("Sukces", "Dodano przesyłkę", "Ok");
                else
                    DisplayAlert("Błąd", "Nie można dodać przesyłki", "Ok");
            }
        }
    }
}