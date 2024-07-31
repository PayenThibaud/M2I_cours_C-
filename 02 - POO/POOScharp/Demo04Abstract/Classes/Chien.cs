using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04Abstract.Classes
{
    internal class Chien : Mammal
    {
        private int _nbBones;
        private RaceChien _race;

        public int NbBones { get => _nbBones; set => _nbBones = value; }

        public Chien(int nbBones) : base() {
            _nbBones = nbBones;
        }

        public Chien(string name, int nbBones, RaceChien raceChien) : base(name)
        {
            _nbBones = nbBones;
            _race = raceChien;
        }

        // Pour redéfinir la méthode issue du parent chez un enfant, on n'oublie pas le mot-clé 'override', qui est complémentaire du mot-clé 'virtual' chez le parent
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

    }
}
