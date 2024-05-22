using AppLourdAVS.DBLib.Class;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppLourdAVS.Wpf.ViewModels
{
    public class ViewModelType
    {
        public DBLib.Class.Type? SelectedType { get; set; }
        public DBLib.Class.Type? NewType { get; set; }
        public ObservableCollection<DBLib.Class.Type> Types { get; set; }

        private DBLib.Class.Type? _originalSelectedType;

        public ViewModelType()
        {
            ResetNewType();
            using (AvsContext mg = new AvsContext())
            {
                Types = new ObservableCollection<DBLib.Class.Type>(mg.Types.ToList());
            }
        }

        public void ResetNewType()
        {
            NewType = new DBLib.Class.Type(); // Crée un nouvel objet Type vide
        }

        public void SaveOriginalSelectedType()
        {
            if (this.SelectedType != null)
            {
                // Cloner l'objet SelectedType pour sauvegarder l'état initial
                _originalSelectedType = new DBLib.Class.Type
                {
                    Id = this.SelectedType.Id,
                    Name = this.SelectedType.Name
                    // Ajoutez d'autres propriétés ici si nécessaire
                };
            }
        }

        public void RestoreOriginalSelectedType()
        {
            if (this.SelectedType != null && _originalSelectedType != null)
            {
                // Restaurer les propriétés de l'objet SelectedType à partir de _originalSelectedType
                this.SelectedType.Id = _originalSelectedType.Id;
                this.SelectedType.Name = _originalSelectedType.Name;
                // Ajoutez d'autres propriétés ici si nécessaire
            }
        }

        internal void CreateType()
        {
            using (AvsContext context = new())
            {
                if (this.NewType == null)
                {
                    this.NewType = new DBLib.Class.Type();
                }

                context.Add(this.NewType); // J'ajoute le type au contexte
                context.SaveChanges(); // Je sauvegarde les modifications du contexte en base de données

                this.Types.Add(this.NewType); // Ajouter à la collection pour mise à jour de la vue
                this.SelectedType = this.NewType;

                ResetNewType(); // Réinitialiser après la sauvegarde
            }
        }

        internal void EditType()
        {
            if (SelectedType != null)
            {
                using (AvsContext context = new())
                {
                    context.Update(SelectedType);
                    context.SaveChanges();
                }

                ResetNewType();
            }
        }

        internal void DeleteType()
        {
            if (SelectedType != null)
            {
                using (AvsContext context = new())
                {
                    context.Remove(SelectedType);
                    context.SaveChanges();
                }
                this.Types?.Remove(SelectedType);
            }
        }
    }
}
