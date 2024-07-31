using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Hotel.Models
{
    internal class Client
    {
        [Key]
        // {Entity}Id ou Id si on respecte la convention
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Required rend la colonne NOT NULL en base de données
        [Required]
        [Column("NumeroTelephone")]
        public string? Telephone { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
    }
}
