using System.Windows;

namespace AppLourdAVS.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowsLogin.xaml
    /// </summary>
    public partial class WindowsLogin : Window
    {
        public WindowsLogin()
        {
            InitializeComponent();
            this.DataContext = new ViewModelLogin();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelLogin)this.DataContext).Password = PasswordBoxLogin.Password;
            ((ViewModelLogin)this.DataContext).Login();
        }
    }
}
