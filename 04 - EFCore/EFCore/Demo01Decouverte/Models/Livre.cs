using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01Decouverte
{
    internal class Livre
    {
        // L'ID est détecté automatique si s'apelle Id OU <NomEntité>Id
        // [Key] A préciser lorsque l'on ne respecte pas la convention
        public int Id { get; set; }

        [MinLength(5), MaxLength(200)]
        public string Titre { get; set; }
        public string? Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DatePublication { get; set; }
    }
}
