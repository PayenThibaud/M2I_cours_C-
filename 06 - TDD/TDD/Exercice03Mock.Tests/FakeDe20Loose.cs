using Demo03Mock.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03Mock.Tests
{
    /// <summary>
    /// Dé pipé pour toujours perdre au Jeu
    /// </summary>
    public class FakeDe20Loose : IDe
    {
        public int Lancer()
        {
            return 19;
        }
    }
}
