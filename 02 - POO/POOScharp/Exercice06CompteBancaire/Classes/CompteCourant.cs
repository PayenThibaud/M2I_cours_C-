using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice06CompteBancaire.Classes
{
    // Cette classe est ni plus ni moins qu'un compte bancaire implémentant ses méthodes
    internal class CompteCourant : CompteBancaire
    {
        public CompteCourant(Client client, decimal solde = 0m) : base(client, solde)
        {
        }

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
    }
}
