using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    internal class Chat
    {
        private string _nom;

        public string Nom { 
            get => _nom;  
            set
            {
                if (value != "Babar") _nom = value;
            }
        }

        public int Age { get; private set; }
        public bool BoitDuLait { get; init; }

        public Chat(bool boitDuLait)
        {
            // On peut set la valeur de la variable uniquement à l'initialisation
            BoitDuLait = boitDuLait;
        }

        public void Anniversaire()
        {
            // Code possible ici car le setter est privé et on est dans le code de la classe 
            Age++;

            // Code ci dessous impossible car la propriété peut être donnée uniquement à l'initialisation
            //BoitDuLait = false;
        }
    }
}
