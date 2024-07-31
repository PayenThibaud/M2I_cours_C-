using Demo05Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    internal class Avion : IVolant, IDemarrant
    {
        public bool Demarrer()
        {
            return true;
        }

        public bool Senvoler()
        {
            Console.WriteLine("L'avion s'envole");
            return true;
        }
    }
}
