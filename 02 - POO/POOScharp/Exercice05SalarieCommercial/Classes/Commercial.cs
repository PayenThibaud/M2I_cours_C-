using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice05SalarieCommercial.Classes
{
    internal class Commercial : Salarie
    {
        private decimal _chiffreAffaire;
        private float _commission;

        public decimal ChiffreAffaire { get => _chiffreAffaire; }
        public float Commission { get => _commission; }

        public Commercial(string service, string categorie, string nom, decimal salaire, decimal chiffreAffaire, float commission) : base(service, categorie, nom, salaire)
        {
            _chiffreAffaire = chiffreAffaire;
            _commission = commission;
        }

        public Commercial(string service, string categorie, string nom, decimal salaire) : base(service, categorie, nom, salaire)
        {
            _chiffreAffaire = 0m;
            _commission = 0.0f;
        }

        // On surcharge la méthode du parent pour obtenir un affichage spécifique aux commerciaux. Cet affichage va prendre en compte la commission et le chiffre d'affaire
        public override void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {_nom} est de {_salaire + decimal.Multiply(_chiffreAffaire, (decimal) _commission)}€");
        }

        // On fait une surcharge de la méthode ToString() de sorte à pouvoir obtenir une version textuelle des informations de notre Commercial. Par exemple, on pourrait vouloir le passer en paramètre d'un Console.WriteLine();
        public override string ToString()
        {
            return $"Commercial [Matricule: {_matricule}, Nom: {_nom}, Service: {_service}, Catégorie: {_categorie}, Salaire: {_salaire}, Commission: {_commission}, Chiffre d'affaire: {_chiffreAffaire}]";
        }
    }
}
