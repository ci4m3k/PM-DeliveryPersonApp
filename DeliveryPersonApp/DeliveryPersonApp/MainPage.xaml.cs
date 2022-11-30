using DeliveryPersonApp.NavPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryPersonApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            profileImage.Source = ImageSource.FromResource("DeliveryPersonApp.Assets.Images.logo.png", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (!isEmailEmpty && !isPasswordEmpty)
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Błąd", "Nie podano adresu email lub hasła", "Ok");
            }

            // walidacja
        }
    }
}
