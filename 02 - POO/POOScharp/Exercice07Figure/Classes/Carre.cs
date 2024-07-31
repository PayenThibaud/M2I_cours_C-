using Exercice07Figure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07Figure.Classes
{
    // Un carré ayant une longueur et une largeur égales, on va simplement avoir la valeur de longueur de côté et faire nos calculs à partir de ça
    internal class Carre : Figure, IDeformable
    {
        private double _cote; 

        public double Cote { get => _cote; }

        public Carre(Point origin, double cote) : base(origin)
        {
            _cote = cote;
        }

        public override string ToString()
        {
            return "=== Carré ===" +
                $"\nA: {_origin.X};{_origin.Y}" +
                $"\nB: {_origin.X + _cote};{_origin.Y}" +
                $"\nC: {_origin.X + _cote};{_origin.Y + _cote}" +
                $"\nD: {_origin.X};{_origin.Y + _cote}";
        }

        // Un carré pouvant rester un carré ou devenir un réctangle si on change son rapport hauteur / largeur, il implémente la méthode Déformer via l'héritage d'IDeformable
        public Figure Deformer(double x, double y)
        {
            if (_cote * x == _cote * y) return new Carre(_origin, _cote * x);
            return new Rectangle(_origin, _cote * x, _cote * y);
        }
    }
}
