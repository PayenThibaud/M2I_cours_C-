using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04Abstract.Classes
{
    // Une classe scellée n'est pas disponible pour un héritage. Il n'est pas possible du coup d'aller hériter de cette classe pour par la suite aller extraire ses champs ou ses informations. Ce genre de classe se retrouvera principalement si l'on partage non pas le code source mais les dépendances sous forme de .dll (déjà compilé)
    internal sealed class Parent
    {
        //public abstract bool EstLeve();

        public bool AMange()
        {
            return true;
        }
    }
}
