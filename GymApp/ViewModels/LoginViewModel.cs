using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using GymApp.Data;

namespace GymApp.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public IRelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            using (var context = new GymAppContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    // Navigate to main view
                    var mainView = new MainView { DataContext = new MainViewModel { Username = Username } };
                    mainView.Show();
                    Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive).Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
        }
    }
}
