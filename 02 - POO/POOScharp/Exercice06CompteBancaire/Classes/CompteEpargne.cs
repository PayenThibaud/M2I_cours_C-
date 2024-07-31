using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06CompteBancaire.Classes
{
    internal class CompteEpargne : CompteBancaire
    {
        // Un compte épargne se caractérise par la capacité à générer des revenus via un taux d'intérêt. On va donc devoir lier un Compte Epargne à un taux d'intérêts
        private float _tauxInterets; 

        public float TauxInterets { get => _tauxInterets; }

        // Quand on créé un compte épargne, on va avoir un taux d'intérêt décidé dés création du compte
        public CompteEpargne(Client client, float tauxInterets, decimal solde = 0m) : base(client, solde)
        {
            _tauxInterets = tauxInterets;
        }

        // Le code des dépots et des retrait est le même que pour un compte courant classique
        public override bool Depot(decimal value)
        {
            _operations.Add(new Operation(value, TypeOperation.DEPOT));
            _solde += value;
            return true;
        }

        public override bool Retrait(decimal value)
        {
            if (_solde - value < 0) return false;

            _operations.Add(new Operation(value, TypeOperation.RETRAIT));
            _solde -= value;
            return true;
        }

        // Pour un compte épargne, on doit pouvoir générer des revenus via une méthode prévue pour cela
        public void Epargner()
        {
            _solde += decimal.Multiply(_solde, (decimal) _tauxInterets);
        }
    }
}
