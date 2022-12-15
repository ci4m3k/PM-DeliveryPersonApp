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

            var assembly = typeof(ProfilePage);
            profileImage.Source = ImageSource.FromResource("DeliveryPersonApp.Assets.Images.ic_launcher.png", assembly);
        }

        private async void makePhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });
                if (photo != null)
                    profileImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }

        }
    }
}