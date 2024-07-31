using Exercice07Figure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice07Figure.Classes
{
    // Toutes les classes futures doivent pouvoir se déplacer (le triangle, le rectangle et le carré)

    // On va donc hériter directement dans leur classe parent de IDeplacable de sorte à ce que les trois en héritent directement
    internal abstract class Figure : IDeplacable
    {
        // Il nous faut une référence d'origine pour nos figures, de sorte à garder la position du point A en mémoire
        protected Point _origin; 

        public Point Origin { get => _origin; }

        // Toute figure demandera l'origine en valeur d'initialisation
        protected Figure(Point origin)
        {
            _origin = origin;
        }

        // Toute figure pouvant se déplacer, on va directement implémenter la méthode ici
        public void Deplacement(double x, double y)
        {
            _origin.X += x;
            _origin.Y += y;
        }
    }
}
