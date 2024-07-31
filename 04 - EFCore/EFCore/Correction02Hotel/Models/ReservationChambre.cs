using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Hotel.Models
{

    // Cette classe sert de jointure entre une réservation et une chambre
    // A partir de la version 7 de EFCore, il est possible d'utiliser l'annotation suivante:
    // [PrimaryKey(nameof(ChambreNumero), nameof(ReservationId))] 
    // Dans notre cas, cette clé composite sera située dans notre DbContext avec la fluent API
    internal class ReservationChambre
    {
        [ForeignKey(nameof(Chambre))]
        public int ChambreNumero { get; set; }
        public Chambre? Chambre { get; set; }


        // [ForeignKey(nameof(Reservation))]
        // si on utilise la syntaxe par défaut du style {Entity}Id
        // l'annotation ForeignKey n'est pas obligatoire
        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
