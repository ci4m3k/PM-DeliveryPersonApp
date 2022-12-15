using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DeliveryPersonApp.ViewModel
{
    public class MainVM
    {
        public ObservableCollection<Account> Accounts { get; set; } 

        public Account SelectedUser { get; set; } 
        
        public MainVM() 
        {
            List<Account> accountList = new List<Account>()
            {
                new Account()
                {
                    Email = "kurier@myparcel.pl",
                    Password = "123456",
                    UserId = "1111",
                    FirstName = "Marcin",
                    LastName = "Kozik",
                    //ProfileImgSource = ImageSource.FromResource("DeliveryPersonApp.Assets.Images.logo.png")
                }
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //Accounts.Clear();

                conn.CreateTable<Account>();
                var accounts = conn.Table<Account>().ToList();

                if (accounts.Count == 0)
                {
                    foreach (var account in accountList)
                    {
                        accounts.Add(account);
                    }
                }

                SelectedUser = accounts[0];
            }
        } 
    }
}
