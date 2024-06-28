using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using GymApp.Views;
using System.Windows.Input;

namespace GymApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
            MessageBox.Show("MainViewModel initialized from MV model");
        }

        private void Logout()
        {
            var loginView = new Views.LoginView();
            loginView.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginView;
        }
    }
}