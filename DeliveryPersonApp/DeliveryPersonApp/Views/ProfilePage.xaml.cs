using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryPersonApp.Model;
using DeliveryPersonApp.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryPersonApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(Account selectedUser)
        {
            InitializeComponent();

            (Resources["vm"] as ProfileVM).SelectedUser = selectedUser;
            (Resources["vm"] as ProfileVM).CurrentPage = this;

            var assembly = typeof(ProfilePage);

            if (selectedUser.ProfileImagePath == null)
                profileImage.Source = ImageSource.FromResource("DeliveryPersonApp.Assets.Images.ic_launcher.png", assembly);
            else
                profileImage.Source = ImageSource.FromFile(selectedUser.ProfileImagePath);
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}