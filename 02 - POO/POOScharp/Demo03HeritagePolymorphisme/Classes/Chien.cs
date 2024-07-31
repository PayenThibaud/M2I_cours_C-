using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03HeritagePolymorphisme.Classes
{
    internal class Chien : Mammal
    {
        private int _nbBones;

        public int NbBones { get => _nbBones; set => _nbBones = value; }

        public Chien(int nbBones) : base() {
            _nbBones = nbBones;
        }

        public Chien(string name, int nbBones) : base(name)
        {
            _nbBones = nbBones;
        }

        // Pour redéfinir la méthode issue du parent chez un enfant, on n'oublie pas le mot-clé 'override', qui est complémentaire du mot-clé 'virtual' chez le parent
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

    }
}
