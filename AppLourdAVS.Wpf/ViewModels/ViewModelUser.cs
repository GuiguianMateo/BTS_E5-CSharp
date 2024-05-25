using AppLourdAVS.DBLib.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace AppLourdAVS.Wpf.ViewModels
{
    public class ViewModelUser
    {
        public User? SelectedUser { get; set; }
        public User? NewUser { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private User? _originalSelectedUser;

        private ICollectionView _filteredUsers;

        public ICollectionView FilteredUsers
        {
            get { return _filteredUsers; }
            set
            {
                _filteredUsers = value;
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelUser()
        {
            ResetNewUser();
            using (AvsContext mg = new AvsContext())
            {
                Users = new ObservableCollection<User>(mg.Users.ToList());
            }

            FilteredUsers = CollectionViewSource.GetDefaultView(Users);
            FilteredUsers.Filter = user => ((User)user).Client == true;
        }

        public void ResetNewUser()
        {
            NewUser = new User(); // Crée un nouvel User vide
        }

        public void SaveOriginalSelectedUser()
        {
            if (this.SelectedUser != null)
            {
                // Sauvegarder les données SelectedUser
                _originalSelectedUser = new DBLib.Class.User
                {
                    Name = this.SelectedUser.Name,
                    Firstname = this.SelectedUser.Firstname,
                    Gender = this.SelectedUser.Gender,
                    Birthday = this.SelectedUser.Birthday,
                    Email = this.SelectedUser.Email,
                    CreatedAt = this.SelectedUser.CreatedAt
                };
            }
        }

        public void RestoreOriginalSelectedUser()
        {
            if (this.SelectedUser != null && _originalSelectedUser != null)
            {
                // Restaurer les propriétés
                this.SelectedUser.Name = _originalSelectedUser.Name;
                this.SelectedUser.Firstname = _originalSelectedUser.Firstname;
                this.SelectedUser.Gender = _originalSelectedUser.Gender;
                this.SelectedUser.Birthday = _originalSelectedUser.Birthday;
                this.SelectedUser.Email = _originalSelectedUser.Email;
                this.SelectedUser.CreatedAt = _originalSelectedUser.CreatedAt;
            }
        }

        internal void EditUser()
        {
            if (SelectedUser != null)
            {
                using (AvsContext context = new())
                {
                    context.Update(SelectedUser);
                    context.SaveChanges();
                }

                ResetNewUser();
            }
        }

        internal void DeleteUser()
        {
            if (SelectedUser != null)
            {
                using (AvsContext context = new())
                {
                    context.Remove(SelectedUser);
                    context.SaveChanges();
                }
                this.Users?.Remove(SelectedUser);
            }
        }
    }
}
