using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07Figure.Classes
{
    // Un point se caractérise par une position en X et une position en Y
    internal class Point
    {
        private double _x;
        private double _y;

        public double X { get => Math.Round(_x, 2); set => _x = value; }
        public double Y { get => Math.Round(_y, 2); set => _y = value; }

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // L'affichage du point est simplement celles des positions X et Y
        public override string ToString()
        {
            return $"{_x};{_y}";
        }
    }
}
