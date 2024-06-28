using GymApp.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new GymAppContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var loginView = new Views.LoginView();
            loginView.Show();
        }
    }

}
