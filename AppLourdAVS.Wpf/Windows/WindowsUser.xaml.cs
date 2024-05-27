using AppLourdAVS.DBLib.Class;
using AppLourdAVS.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AppLourdAVS.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowsUser.xaml
    /// </summary>
    public partial class WindowsUser : UserControl
    {
        public WindowsUser()
        {
            InitializeComponent();
            DataContext = new ViewModelUser();

        }

        private void Edit_User_Click(object sender, RoutedEventArgs e)
        {
            WindowsEditUser formModif = new WindowsEditUser(((ViewModelUser)this.DataContext));
            formModif.ShowDialog();
        }

        private void Delete_User_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelUser)this.DataContext).SelectedUser != null)
            {
                using (AvsContext context = new AvsContext())
                {

                    if (context.Consultations.Any(c => c.UserId == ((ViewModelUser)this.DataContext).SelectedUser.Id))
                    {
                        MessageBox.Show("Impossible de supprimer cet utilisateur car il est lié à une ou plusieurs consultations", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (context.Demandes.Any(p => p.UserId == ((ViewModelUser)this.DataContext).SelectedUser.Id))
                    {
                        MessageBox.Show("Impossible de supprimer cet utilisateur car il est lié à un ou plusieurs demandes.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ((ViewModelUser)this.DataContext).DeleteUser();
                    }
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).Logout();
        }
    }
}
