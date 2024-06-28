﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using GymApp.Data;
using System.Windows.Input;
using GymApp.Views;

namespace GymApp.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        private string _password;
        private readonly GymAppContext _context;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _context = new GymAppContext();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            try
            {
                MessageBox.Show("Attempting login...");
                var user = _context.Users.SingleOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    MessageBox.Show("Login successful!");
                    // Navigate to MainView
                    MainView mainView = new MainView();
                    var mainViewModel = new MainViewModel { Username = Username };
                    mainView.DataContext = mainViewModel;
                    Application.Current.MainWindow = mainView;
                    mainView.Show();
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive).Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error is : {ex.Message}");
            }
    
        }
    }
}
