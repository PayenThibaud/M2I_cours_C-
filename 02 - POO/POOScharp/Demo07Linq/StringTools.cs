using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07Linq
{
    // Pour créer des extensions de méthodes, il faut créer des méthodes statiques dans une classe statique (le nom de la classe importe peu)
    internal static class StringTools
    {
        public static string ToCapitalized(this string value) // Dans une méthode statique, on peut utiliser un premier paramètre précédé du mot-clé 'this'. Ce paramètre sera au final le type d'élément auquel on va ajouter notre méthode. Ici, pour toute chaine de caractère, on bénéficiera donc d'une méthode .ToCapitalized() effectuant ce code :
        {
            string returnValue = "";
            foreach (var mot in value.Split(" "))
            {
                returnValue += mot.Substring(0, 1).ToUpper() + mot.Substring(1).ToLower();
            }
            return returnValue;
        }

        
    }
}
