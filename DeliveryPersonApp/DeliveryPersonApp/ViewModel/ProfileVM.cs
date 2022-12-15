using DeliveryPersonApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace DeliveryPersonApp.ViewModel
{
    public class ProfileVM : INotifyPropertyChanged
    {
        private Account selectedUser;
        public Account SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ProfileVM() 
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
