using AppLourdAVS.DBLib.Class;
using AppLourdAVS.Wpf.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AppLourdAVS.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public User? Auth { get; set; }


        public void Login(User user)
        {
            Auth = user;
            MainWindow mainWindow = new();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }


        public void Logout()
        {
            Auth = null;
            WindowsLogin windowsLogin = new();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = windowsLogin;
            windowsLogin.Show();
        }
    }

}
