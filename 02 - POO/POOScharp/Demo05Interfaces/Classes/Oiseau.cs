using Demo05Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    internal class Oiseau : Animal, IVolant
    {
        private bool _migre;

        //public bool Migre { get => _migre; }
        public bool Migre { get => _migre; set => _migre = value; }
        public Oiseau(string nom) : base(nom)
        {
        }

        public override void MakeSound()
        {
            throw new NotImplementedException();
        }

        public bool PartEnVoyage()
        {
            _migre = true;
            return true;
        }

        public bool Senvoler()
        {
            return true;
        }
    }
}
