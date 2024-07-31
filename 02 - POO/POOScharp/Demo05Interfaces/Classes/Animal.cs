using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    internal abstract class Animal
    {
        private static int _count = 0;

        protected string _nom;
        protected int _id;

        public string Nom { get => _nom; }
        public int Id { get => _id; }

        public int Age { get; set; }

        protected Animal(string nom)
        {
            _id = ++_count;

            _nom = nom;
        }

        // On peut définir une méthode dans une classe sans en écrire le corps via des méthodes abstraites, ce uniquement dans le cas où notre classe est abstraite
        public abstract void MakeSound();
    }
}
