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
    /// Logique d'interaction pour WindowsCreateType.xaml
    /// </summary>
    public partial class WindowsCreateType : Window
    {
        public WindowsCreateType(ViewModelType context)
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void Create_Type_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelType)this.DataContext).CreateType();
            this.Close();
        }

        private void Annuler_Create_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumericTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (var c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true; // Ignore tous les caractères qui ne sont pas des chiffres
                    return;
                }
            }
        }
    }
}
