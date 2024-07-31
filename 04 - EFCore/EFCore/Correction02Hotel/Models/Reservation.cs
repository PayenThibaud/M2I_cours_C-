using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Correction02Hotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public StatutReservation Statut { get; set; }

        [JsonIgnore]
        public List<ReservationChambre> ReservationChambres { get; set; } = new();

        // Sans l'utilisation des conventions, il est nécessaire d'utiliser les annotations pour liés les propriétés de navigation
        [ForeignKey(nameof(Client))]
        public int ClientIdentifiant { get; set; }
        public Client Client { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    enum StatutReservation
    {
        Prevu,
        EnCours,
        Fini,
        Annule
    }
}
