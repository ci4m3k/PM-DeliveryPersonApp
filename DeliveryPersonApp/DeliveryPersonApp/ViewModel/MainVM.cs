using DeliveryPersonApp.Model;
using DeliveryPersonApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryPersonApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public Command LoginCommand { get; set; }

        public ObservableCollection<Account> Accounts { get; set; } 

        public Account SelectedUser { get; set; }

        public Page CurrentPage { get; set; }

        private string email;
        public string Email 
        { 
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password 
        { 
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool loginIsReady;
        public bool LoginIsReady
        {
            get { return true; }
        }

        private static string dbName = "account_db.sqlite";
        private static string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private string fullPath = Path.Combine(folderPath, dbName);

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM() 
        {
            LoginCommand = new Command<bool>(Login, CanLogin);

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
                        Accounts.Add(account);
                    }
                }

                SelectedUser = conn.Table<Account>().ToList()[0];
            }
        }

        private async void Login(bool parameter)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(Email);
            bool isPasswordEmpty = string.IsNullOrEmpty(Password);

            bool isDataCorrect = false;

            foreach (var account in Accounts)
            {
                if (Email == account.Email && Password == account.Password)
                {
                    isDataCorrect = true;
                    break;
                }
            }

            if (!isEmailEmpty && !isPasswordEmpty)
            {
                if (isDataCorrect)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage(SelectedUser));
                    App.Current.MainPage.Navigation.RemovePage(CurrentPage);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Błąd", "Podany email lub hasło jest błędny!", "Ok");
                    Password = null;
                }
            }
            else
                await App.Current.MainPage.DisplayAlert("Błąd", "Nie podano adresu email lub hasła!", "Ok");
        }

        private bool CanLogin(bool parameter)
        {
           return parameter;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
