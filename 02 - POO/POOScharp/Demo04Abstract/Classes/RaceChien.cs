using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04Abstract.Classes
{
    // Un enum est un type particulier qui pourrait s'apparenter à un tableau de valeur constantes. Il est utilisé dans un but d'optimisation du temps de developpement (Pas besoin d'écrire plein de fois les textes, on a une auto-complétion et on évite ainsi les erreurs typographiques).

    // Son autre avantage est vis à vis de la compilation. Une valeur constante / un enum va être remplacée directement par sa valeur au moment de la compilation, ce qui va éviter d'avoir à faire ce processus durant l'exécution du programme chez chaque personne exécutant notre appli.
    internal enum RaceChien
    {
        DOBERMAN,
        LABRADOR,

    }
}
