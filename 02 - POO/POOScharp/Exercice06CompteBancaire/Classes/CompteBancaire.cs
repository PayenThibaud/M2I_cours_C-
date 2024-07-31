using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06CompteBancaire.Classes
{
    internal abstract class CompteBancaire
    {
        // Pour une classe abstraite, les champs doivent idéalement être protégés de sorte à être accessibles aux enfants
        protected decimal _solde;
        protected Client _client;
        protected List<Operation> _operations;

        // Si l'on veut rendre ces champs accessibles en dehors de notre classe, il nous faut des propriétés publiques
        public decimal Solde { get => _solde; }
        public Client Client { get => _client; }
        public List<Operation> Operations { get => _operations; }


        // Un constructeur protégé va pouvoir être appellé par les classes enfants mais pas les classes extérieures à l'héritage
        protected CompteBancaire(Client client, decimal solde = 0m)
        {
            _client = client;

            _solde = solde;
            _operations = new();
        }

        // On peut créer des méthodes 'en attente' via des méthodes abstraites. Ces méthodes n'ont pour le moment pas de code mais forceront les classes enfants de CompteBancaire à permettre un Depot et un Retrait
        public abstract bool Depot(decimal value);

        public abstract bool Retrait(decimal value);

        // L'affichage des Opération sera commun entre les 3 classes enfants, autant le définir dans le parent pour éviter les redites
        public void AfficherOperationSolde()
        {
            if (_operations.Count > 0)
            {
                Console.WriteLine("\n=== Liste des opérations ===");
                foreach (Operation o in _operations)
                {
                    Console.WriteLine(o);
                }
            } else
            {
                Console.WriteLine("Il n'y a pas encore eu d'opération sur ce compte.");
            }

            
            Console.WriteLine($"Solde du compte: {_solde}€");
        }
    }
}
