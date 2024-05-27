using System.Windows;
using System.Windows.Forms;
using AppLourdAVS.Wpf;
using Microsoft.VisualBasic.ApplicationServices;
using MessageBox = System.Windows.Forms.MessageBox;
using AppLourdAVS.DBLib.Class;
using System.Windows.Input;

namespace AppLourdAVS.Wpf
{
    internal class ViewModelLogin
    {
        #region Fields

        public string? Email { get; set; }
        public string? Password { get; set; }

        #endregion

        public void Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AvsContext context = new AvsContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email.Equals(Email));

                if (user != null)
                {
                    if (user.Client == false)
                    {
                        if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
                        {
                            ((App)System.Windows.Application.Current).Login(user);
                        }
                        else
                        {
                            MessageBox.Show("Mot de passe incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas les autorisations nécessaires pour accéder à cette application", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Adresse mail introuvable", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
