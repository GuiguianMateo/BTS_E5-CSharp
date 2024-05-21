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
    /// Logique d'interaction pour WindowsEditType.xaml
    /// </summary>
    public partial class WindowsEditType : Window
    {
        public int MyProperty { get; set; }
        public WindowsEditType(ViewModelType context)
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void Edit_Type_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelType)this.DataContext).SelectedType != null)
            {
                ((ViewModelType)this.DataContext).EditType();
                this.Close();

            }
        }

        private void Annuler_Edit_Click(object sender, RoutedEventArgs e)
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
