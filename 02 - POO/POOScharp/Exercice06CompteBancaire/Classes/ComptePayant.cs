using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06CompteBancaire.Classes
{
    internal class ComptePayant : CompteBancaire
    {
        // Un compte payant se caractérise par un prix à payer pour chaque opération, qu'il s'agisse d'un retrait ou d'un dépot
        private readonly decimal _coutOperation;

        // On initialise dont un compte payant avec un montant correspondant au coùut des opérations
        public ComptePayant(Client client, decimal coutOperation, decimal solde = 0) : base(client, solde)
        {
            _coutOperation = coutOperation;
        }

        // Le code des dépots et des retrait va prendre en compte ce coût d'opération dans les instructions

        // Encore une fois, nous n'autorisons pas le découvert ici
        public override bool Depot(decimal value)
        {
            if (_solde - _coutOperation < 0m) return false;

            _operations.Add(new Operation(value, TypeOperation.DEPOT));
            _solde += value - _coutOperation;

            return true;
        }

        public override bool Retrait(decimal value)
        {
            if (_solde - _coutOperation - value < 0m) return false;

            _operations.Add(new Operation(value, TypeOperation.RETRAIT));
            _solde -= value + _coutOperation;

            return true;

        }
    }
}
