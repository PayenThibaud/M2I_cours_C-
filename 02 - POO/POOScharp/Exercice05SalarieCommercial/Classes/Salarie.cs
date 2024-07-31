using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice05SalarieCommercial.Classes
{
    internal class Salarie
    {
        protected int _matricule;
        protected string _service;
        protected string _categorie;
        protected string _nom;
        protected decimal _salaire;

        public static int nbSalaries = 0;
        public static decimal salaireTotal = 0m;

        public int Matricule { get => _matricule; }
        public string Service { get => _service; }
        public string Categorie { get => _categorie; }
        public string Nom { get => _nom;}
        public decimal Salaire { get => _salaire; }

        public Salarie(string service, string categorie, string nom, decimal salaire)
        {
            _matricule = ++nbSalaries;
            _service = service;
            _categorie = categorie;
            _nom = nom;
            _salaire = salaire;
            salaireTotal += salaire;
        }

        public static void RemiseAZero()
        {
            nbSalaries = 0;
        }

        // Pour indiquer que la méthode peut être surchargée, on utilise le mot-clé 'virtual'
        public virtual void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {_nom} est de {_salaire}€");
        }

        // On fait une surcharge de la méthode ToString() de sorte à pouvoir obtenir une version textuelle des informations de notre Salarié. Par exemple, on pourrait vouloir le passer en paramètre d'un Console.WriteLine();
        public override string ToString()
        {
            return $"Salarie [Matricule: {_matricule}, Nom: {_nom}, Service: {_service}, Catégorie: {_categorie}, Salaire: {_salaire}]";
        }

    }
}
