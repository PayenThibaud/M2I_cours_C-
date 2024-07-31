using Exercice07Figure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Exercice07Figure.Classes
{
    // Le rectangle va posséder, en plus de la valeur de son origine (le point A), la largeur et la longueur pour calculer au besoin les position de B, C et D
    internal class Rectangle : Figure, IDeformable
    {
        private double _longueur;
        private double _largeur;

        public double Longueur { get => _longueur; }
        public double Largeur { get => _largeur; }
        public Rectangle(Point origin, double longueur, double largeur) : base(origin)
        {
            _longueur = longueur;
            _largeur = largeur;
        }

        public override string ToString()
        {
            return "=== Rectangle ===" +
            $"\nA: {_origin.X};{_origin.Y}" +
            $"\nB: {_origin.X + _longueur};{_origin.Y}" +
            $"\nC: {_origin.X + _longueur};{_origin.Y + _largeur}" +
            $"\nD: {_origin.X};{_origin.Y + _largeur}";
        }

        // Un rectanglepouvant rester un rectangle ou devenir un carré si on change son rapport hauteur / largeur, il implémente la méthode Déformer via l'héritage d'IDeformable
        public Figure Deformer(double x, double y)
        {
            if (_longueur * x == _largeur * y) return new Carre(_origin, _largeur * y);
            return new Rectangle(_origin, _longueur * x, _largeur * y);
        }
    }
}
