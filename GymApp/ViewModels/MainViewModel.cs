using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace GymApp.ViewModels
{
    internal class MainViewModel : ObservableObject
    {

        public string Username { get; set; }
        public IRelayCommand LogoutCommand { get; }

        public MainViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Logout()
        {
            // Jakaś logika do wylogowania
            MessageBox.Show("Logged out");
        }

    }
}
