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
	public partial class DeliveredParcelPage : ContentPage
	{
        private DeliveredParcelVM vm;
        public DeliveredParcelPage ()
		{
			InitializeComponent ();

            vm = Resources["vm"] as DeliveredParcelVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetParcels();
        }
    }
}