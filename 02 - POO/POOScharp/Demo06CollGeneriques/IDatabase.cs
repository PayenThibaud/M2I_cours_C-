using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06CollGeneriques
{
    // Il est possible de créer des interfaces génériques de sorte à créer un contrat 'flexible' (les termes du contrat sont un peu flou, on sait ce que l'on va devoir faire, mais pas encore avec quels types. 

    // Il est d'ailleurs possible de définir plusieurs types à définir plus tard, de même que d'en restreindre les types futurs. Pour cela, on utilise la syntaxe 'where NomType : typeParent'
    internal interface IDatabase<TElement, TID> where TID : struct
    {
        public bool Add(TElement element);
        public TElement? GetById(TID id);

    }
}
