using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Correction02Hotel.Models
{
    internal class Chambre
    {
        // Utilisation de l'annotation key lorsque la convention n'est pas utilisée
        [Key]
        public int Numero { get; set; }
        public StatutChambre Statut { get; set; }
        public int NombreLits { get; set; }

        // Permet de préciser la partie entière et le nombre de décimal en base de données
        [Precision(14, 2)]
        public decimal Tarif { get; set; }

        public List<ReservationChambre> ReservationChambres { get; set; } = new List<ReservationChambre>();

        public string ToJson()
        {
            return $"{{numero: {Numero}, statut: {Statut}, nombreLit: {NombreLits}, tarif: {Tarif}}}";
        }
    }

    // L'énumération est liée au statut de la chambre, il peut dont être intéressant de la stocker à même la classe
    enum StatutChambre
    {
        Libre,
        Occupe,
        Nettoyage
    }
}
