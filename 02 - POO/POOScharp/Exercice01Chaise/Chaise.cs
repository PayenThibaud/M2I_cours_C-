using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice01Chaise
{
    public class Chaise
    {
        private int _nbPieds;
        private string _materiau;
        private string _couleur;

        public int NbPieds { get => _nbPieds; set => _nbPieds = value; }
        public string Materiau { get => _materiau; set => _materiau = value; }
        public string Couleur { get => _couleur; set => _couleur = value; }

        public Chaise()
        {
            NbPieds = 4;
            Materiau = "Bois";
            Couleur = "Blanche";
        }
        public Chaise(int nbPieds, string materiau, string couleur)
        {
            NbPieds = nbPieds;
            Materiau = materiau;
            Couleur = couleur;
        }

        public void Afficher()
        {
            //Console.WriteLine($"Je suis une Chaise, avec {NbPieds} pieds en {Materiau} et de couleur {Couleur}");
            //Console.WriteLine(this.ToString());
            //Console.WriteLine(ToString());

            Console.WriteLine(this);//appelle le ToString implicitement pour write la representation textuelle de la chaise
        }

        public override string ToString() // override remplace le comportement de base de la méthode Object.ToString(), cette méthode donne la représentation textuelle de l'instance 
        {
            return $"Je suis une Chaise, avec {NbPieds} pieds en {Materiau} et de couleur {Couleur}";
        }
    }
}
