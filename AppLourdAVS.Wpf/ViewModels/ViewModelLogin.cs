using System.Windows;
using System.Windows.Forms;
using AppLourdAVS.Wpf;
using AppLourdAVS.DBLib;
using Microsoft.VisualBasic.ApplicationServices;
using MessageBox = System.Windows.Forms.MessageBox;

namespace AppLourdAVS.Wpf
{
    internal class ViewModelLogin
    {
        #region Fields

        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? Client { get; set; }

        #endregion 

       /* public void Login()
        {
            User user = null;
            using (AppLourdAVSContext context = new AppLourdAVSContext())
            {
                user = context.Users.FirstOrDefault(userTemp => userTemp.Name.Equals(Name) && userTemp.Client == 0); // Vérifier que l'utilisateur a le champ Client à 0

                if (user != null)
                {
                    if (user.Client == 0)
                    {
                        // Vérifier le mot de passe haché avec BCrypt
                        if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
                        {
                            ((App)App.Current).Login(user);
                        }
                        else
                        {
                            // Mot de passe incorrect
                            MessageBox.Show("Mot de passe incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // L'utilisateur n'a pas les autorisations nécessaires
                        MessageBox.Show("Vous n'avez pas les autorisations nécessaires pour accéder à cette application", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nom d'utilisateur introuvable
                    MessageBox.Show("Nom d'utilisateur introuvable", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/
    }
}
