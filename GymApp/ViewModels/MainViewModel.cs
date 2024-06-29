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
using GymApp.Data;
using System.Collections.ObjectModel;
using GymApp.Models;

namespace GymApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly GymAppContext _context;
        public ObservableCollection<WorkoutViewModel> UserWorkouts { get; set; }
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

        //DODAnie username do MAIN MODEL VIEW - uzupełnić potem
        public MainViewModel(string username)
        {
            Username = username;
            _context = new GymAppContext();
            UserWorkouts = new ObservableCollection<WorkoutViewModel>();
            LoadUserWorkouts();
            LogoutCommand = new RelayCommand(Logout);
            MessageBox.Show("MainViewModel initialized from MV model");
        }

        private void LoadUserWorkouts()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Username);

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