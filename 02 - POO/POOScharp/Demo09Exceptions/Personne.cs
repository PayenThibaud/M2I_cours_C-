using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo09Exceptions
{
    internal class Personne
    {

        private int _age;
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age
        {
            get => _age;
            set
            {
                if (value > 0 && value < 150)
                {
                    _age = value;
                }
                else
                {
                    throw new AgeException("L'âge doit être compris entre 1 et 149 ans");
                }
            }
        }
    }
}
