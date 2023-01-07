using DeliveryPersonApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            Accounts = new ObservableCollection<Account>();

            List<Account> accountList = new List<Account>()
            {
                new Account()
                {
                    Email = "kurier@myparcel.pl",
                    Password = "123456",
                    UserId = "1111",
                    FirstName = "Marcin",
                    LastName = "Kozik",
                    ProfileImagePath = null
                }
            };

            string dbName = "account_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);

            using (SQLiteConnection conn = new SQLiteConnection(fullPath))
            {
                Accounts.Clear();

                conn.CreateTable<Account>();
                conn.DeleteAll<Account>();
                var accounts = conn.Table<Account>().ToList();

                if (accounts.Count == 0)
                {
                    foreach (var account in accountList)
                    {
                        conn.Insert(account);
                    }
                }

                SelectedUser = conn.Table<Account>().ToList()[0];
            }
        } 
    }
}
