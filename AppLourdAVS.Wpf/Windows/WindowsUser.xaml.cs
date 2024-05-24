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
    }
}
