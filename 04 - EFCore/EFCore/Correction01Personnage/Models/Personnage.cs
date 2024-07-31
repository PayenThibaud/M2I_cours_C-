using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Personnage.Models
{
    internal class Personnage
    {
        // Primary Key car utilisation de la convention de nommage
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int Vie { get; set; }
        public int Armure { get; set; }
        public int Degat { get; set; }
        
        // Valeur par défaut initialisée côté client
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public int NombrePersonnesTues { get; set; }

        public override string ToString()
        {
            return $@"{{
    id: {Id},
    pseudo: {Pseudo},
    vie: {Vie},
    armure: {Armure},
    degat: {Degat},
    creation: {DateCreation:d},
    personnesTues: {NombrePersonnesTues}
}}";
        }
    }
}
