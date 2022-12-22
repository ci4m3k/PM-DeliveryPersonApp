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
    public partial class StatsPage : ContentPage
    {
        private StatsVM vm;
        public StatsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as StatsVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetParcels();
        }
    }
}