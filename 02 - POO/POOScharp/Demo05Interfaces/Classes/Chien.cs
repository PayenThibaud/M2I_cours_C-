using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    internal class Chien : Animal
    {
        private readonly List<string> _jouets;

        public List<string> Jouets { get => _jouets; }

        public Chien(string nom) : base(nom)
        {
            _jouets = new();
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
