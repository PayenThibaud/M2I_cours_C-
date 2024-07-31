using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06CollGeneriques
{
    // On peut hériter d'une interface générique et du coup choisir les types à ce moment
    internal class DatabaseChien : IDatabase<Chien, int>
    {
        // Lors de l'implémentation des méthodes, les types seront donnés de par notre choix de type lors de la définition de l'héritage 
        public bool Add(Chien element)
        {
            throw new NotImplementedException();
        }

        public Chien? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
