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

        //DODAnie username do MAIN MODEL VIEW - zobaczyć jak będzi edziałało z LoginViewModel
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
            try
            {
                // Log to see if the context and Username are set correctly
                MessageBox.Show("Loading workouts for user: " + Username);

                // Ensure context and Username are not null
                if (_context == null)
                {
                    MessageBox.Show("Context is null!");
                    return;
                }
                if (string.IsNullOrEmpty(Username))
                {
                    MessageBox.Show("Username is null or empty!");
                    return;
                }

                var user = _context.Users.FirstOrDefault(u => u.Username == Username);
                if (user != null)
                {
                    // Log user details
                    MessageBox.Show("Found user: " + user.Username);

                    var workouts = _context.Workouts.Where(w => w.UserId == user.UserId).ToList();
                    foreach (var workout in workouts)
                    {
                        UserWorkouts.Add(new WorkoutViewModel
                        {
                            StartTime = workout.StartTime,
                            Name = workout.Name,
                            ExercisesCount = workout.Exercises.Count(),
                            TotalWeight = workout.Exercises.Sum(e => e.Weight * e.Repetitions)
                        });
                    }

                    // Log success
                    MessageBox.Show("Loaded workouts successfully.");
                }
                else
                {
                    MessageBox.Show($"{Username} not found in database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while loading user workouts: {ex.Message}");
            }
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