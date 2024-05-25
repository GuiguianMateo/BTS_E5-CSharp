using AppLourdAVS.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppLourdAVS.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowsEditUser.xaml
    /// </summary>
    public partial class WindowsEditUser : Window
    {
        public WindowsEditUser(ViewModelUser context)
        {
            InitializeComponent();
            context.SaveOriginalSelectedUser();  // Sauvegarder l'état initial
            this.DataContext = context;
        }

        private void Edit_User_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelUser)this.DataContext).SelectedUser != null)
            {
                ((ViewModelUser)this.DataContext).EditUser();
                this.Close();
            }
        }

        private void Annuler_Edit_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelUser)this.DataContext).RestoreOriginalSelectedUser();  // Restaurer l'état initial si annulé
            this.Close();
        }
    }
}
