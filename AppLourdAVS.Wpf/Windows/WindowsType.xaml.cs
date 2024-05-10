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
    /// Logique d'interaction pour WindowsType.xaml
    /// </summary>
    public partial class WindowsType : Window
    {
        public WindowsType()
        {
            InitializeComponent();
            DataContext = new ViewModelType();
        }

        private void Create_Type_Click(object sender, RoutedEventArgs e)
        {
            // Initialiser la vue FormCreateProduitView en transmettant le ViewModelProduit
            WindowsCreateType formCreateProduitView = new WindowsCreateType((ViewModelType)this.DataContext);

            // Afficher la vue

            formCreateProduitView.ShowDialog();

        }

    }
}
