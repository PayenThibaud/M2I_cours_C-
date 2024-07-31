using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06CollGeneriques
{
    // Pour créer une classe générique, il faut respecter la syntaxe suivante
    internal class MaListe<T> // On ajoute la notion de génericité via <NomDuType> (par convention T si un seul type)
    {
        private T[] _mesElements; // Toutes les variables dont le type doit être en lien avec celui choisi par l'utilisateur au moment de l'initialisation d'un objet du type de notre classe générique seront typé via le même nom que celui choisi à la déclaration de la classe
        private int _count;

        public MaListe(int taille)
        {
            _mesElements = new T[taille];
            _count = 0;
        }

        public void AfficheMesElements()
        {
            foreach(T e in _mesElements)
            {
                // Pour vérifier l'égalité à une valeur par défaut en cas d'utilisation de générique, on ne peut pas vérifier directement l'égalité à 0, false, null, etc... Il faut pouvoir récupérer la valeur par défaut du type donné pour la comparé à la valeur de notre variable. Pour cela, on a l'opérateur default()
                if(!e.Equals(default(T))) Console.WriteLine(e);
            }
        }

        public bool Add(T input) // Il en est de même pour les paramètres de méthode
        {

            if (_count < _mesElements.Length)
            {
                _mesElements[_count++] = input;
                return true;
            }

            return false;
        }
    }
}
