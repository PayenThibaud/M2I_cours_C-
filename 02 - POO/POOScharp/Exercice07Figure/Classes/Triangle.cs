using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07Figure.Classes
{
    // Un triangle isocèle aura une origine et deux autres point. Le point B sera au centre de sa base et positionné en Y via la hauteur. Le point C sera à l'autre bout de la base, mais à la même valeur en Y que le point A
    internal class Triangle : Figure
    {
        private double _base;
        private double _hauteur;

        public double Base { get => _base; }
        public double Hauteur { get => _hauteur; }

        public Triangle(Point origin, double baseL, double hauteur) : base(origin)
        {
            _base = baseL;
            _hauteur = hauteur;
        }
        public override string ToString()
        {
            return "=== Triangle ===" +
            $"\nA: {_origin.X};{_origin.Y}" +
            $"\nB: {_origin.X + _base / 2.0};{_origin.Y + _hauteur}" +
            $"\nC: {_origin.X + _base};{_origin.Y}";
        }
    }
}
