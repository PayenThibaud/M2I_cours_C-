using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Core
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Villes non trouvé")
        {
        }
    }
}
