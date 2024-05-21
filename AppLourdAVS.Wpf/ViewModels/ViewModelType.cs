using AppLourdAVS.DBLib.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLourdAVS.Wpf.ViewModels
{
    public class ViewModelType
    {

        public DBLib.Class.Type? SelectedType { get; set; }
        public DBLib.Class.Type? NewType { get; set; }
        public ObservableCollection<DBLib.Class.Type> Types { get; set; }


        public ViewModelType()
        {
            if (this.NewType == null)
            {
                this.NewType = new DBLib.Class.Type();
            }


            using (AvsContext mg = new AvsContext())
            {
                Types = new ObservableCollection<DBLib.Class.Type>(mg.Types.ToList());
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

                context.Add(this.NewType);//J'ajoute le type au contexte

                context.SaveChanges(); // Je sauvegarde les modification du contexte en base de données
                this.Types.Add(this.NewType); // Si j'ai une liste pour la vue, je l'y ajoute pour qu'elle s'affiche
                this.SelectedType = this.NewType;
            }
        }

        internal void EditType()
        {
            if (this.SelectedType is not null)
            {
                using (AvsContext context = new())
                {
                    context.Update(this.SelectedType);
                    context.SaveChanges();
                }

            }
        }
    }
}
