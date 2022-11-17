using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryPersonApp.NavPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

         protected override void OnAppearing()
        {
            base.OnAppearing();

            GetLocation(); 
        }

        private async void GetLocation()
        {
            var status = await CheckAndRequestLocationPermission();

            if(status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLocationAsync();

                locationsMap.IsShowingUser = true;
            }
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if(status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // prompt the user to trun on the permission in settings
                return status;
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status;
        }
    }
}