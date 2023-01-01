using DeliveryPersonApp.Model;
using DeliveryPersonApp.ViewModel;
using DeliveryPersonApp.Views;
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
    public partial class HomePage : TabbedPage
    {
        private Account SelectedUser;
        public HomePage(Account selectedUser)
        {
            InitializeComponent();

            SelectedUser = selectedUser;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage(SelectedUser));
        }

        private void ParcelMenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ParcelMenuPage());
        }

        // temp
        private void AddParcelItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TempAddParcelPage());
        }

        private void MapPage_Appearing(object sender, EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void MapPage_Disappearing(object sender, EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }
}