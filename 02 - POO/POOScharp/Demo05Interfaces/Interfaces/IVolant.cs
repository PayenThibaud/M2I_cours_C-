using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Interfaces
{
    // Une interface permet de mettre en commun des signature de méthodes qui devront être implémentées par les classes héritant de l'interface. Il s'agit en quelque sorte d'un contrat que les classes devront signer et en respecter les clauses
    internal interface IVolant
    {
        
        // Les méthodes écrites dans une interface sont abstraites par défaut, on a pas besoin d'écrire le mot-clé abstract manuellement
        public bool Senvoler();
    }
}
