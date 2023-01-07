﻿using DeliveryPersonApp.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DeliveryPersonApp.ViewModel
{
    public class ProfileVM : INotifyPropertyChanged
    {
        public Command MakePhotoCommand { get; set; }

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

        private string profileImagePath;
        public string ProfileImagePath 
        { 
            get { return profileImagePath; }
            set
            {
                profileImagePath = value;
                OnPropertyChanged("ProfileImagePath");
            }
        }

        private bool photoIsReady;
        public bool PhotoIsReady
        {
            get { return true; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileVM() 
        {
            MakePhotoCommand = new Command<bool>(Save, CanSave);
        }

        private async void Save(bool parameter)
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });
                if (photo != null)
                {
                    ProfileImagePath = photo.Path;
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }

            string dbName = "account_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);

            SelectedUser.ProfileImagePath = ProfileImagePath;

            using (SQLiteConnection conn = new SQLiteConnection(fullPath))
            {
                conn.CreateTable<Account>();
                conn.Update(SelectedUser);
            }
        }

        private bool CanSave(bool parameter)
        {
            return parameter;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
