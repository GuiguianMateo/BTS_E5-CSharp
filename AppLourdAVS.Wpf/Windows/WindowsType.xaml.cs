﻿using AppLourdAVS.DBLib.Class;
using AppLourdAVS.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AppLourdAVS.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowsType.xaml
    /// </summary>
    public partial class WindowsType : UserControl
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

        private void Edit_Type_Click(object sender, RoutedEventArgs e)
        {
            WindowsEditType formModif = new WindowsEditType(((ViewModelType)this.DataContext));
            formModif.ShowDialog();
        }

        private void Delete_Type_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelType)this.DataContext).SelectedType != null)
            {
                using (AvsContext context = new AvsContext())
                {

                    if (context.Consultations.Any(c => c.TypeId == ((ViewModelType)this.DataContext).SelectedType.Id))
                    {
                        MessageBox.Show("Impossible de supprimer ce type car il est lié à une ou plusieurs consultations", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (context.Praticiens.Any(p => p.TypeId == ((ViewModelType)this.DataContext).SelectedType.Id))
                    {
                        MessageBox.Show("Impossible de supprimer ce type car il est lié à un ou plusieurs praticiens.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ((ViewModelType)this.DataContext).DeleteType();
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
    