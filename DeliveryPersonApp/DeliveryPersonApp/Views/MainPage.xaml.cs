using DeliveryPersonApp.Model;
using DeliveryPersonApp.ViewModel;
using DeliveryPersonApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryPersonApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainVM vm;
        public MainPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as MainVM;
            vm.CurrentPage = this;

            var assembly = typeof(MainPage);
            profileImage.Source = ImageSource.FromResource("DeliveryPersonApp.Assets.Images.logo.png", assembly);
        }
    }
}
