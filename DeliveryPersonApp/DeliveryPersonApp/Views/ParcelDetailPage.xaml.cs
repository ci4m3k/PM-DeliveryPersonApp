using DeliveryPersonApp.Model;
using DeliveryPersonApp.ViewModel;
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
    public partial class ParcelDetailPage : ContentPage
    {
        public ParcelDetailPage(Parcel selectedParcel)
        {
            InitializeComponent();

            (Resources["vm"] as ParcelDetailVM).SelectedParcel = selectedParcel;
        }
    }
}