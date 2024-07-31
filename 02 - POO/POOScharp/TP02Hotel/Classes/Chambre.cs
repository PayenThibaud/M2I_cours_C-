namespace TP02Hotel.Classes
{
    public enum StatutChambre
    {
        LIBRE,
        OCCUPEE,
        EN_NETTOYAGE
    }
    public class Chambre
    {
        public int Numero { get; init; }
        public StatutChambre Statut { get; set; } = StatutChambre.LIBRE;
        public int NbLits { get; set; } = 2;
        public decimal Tarif { get; set; } = 24.00m;
    }
}