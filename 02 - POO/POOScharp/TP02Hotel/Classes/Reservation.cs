namespace TP02Hotel.Classes
{
    public enum StatutReservation
    {
        PREVU,
        EN_COURS,
        FINI,
        ANNULEE
    }

    public record Reservation
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public DateTime Debut { get; init; } = DateTime.Now;
        public DateTime Fin { get; init; } = DateTime.Now.AddDays(1.0);
        public decimal SommeTotale { get => Chambres.Sum(x => x.Tarif); }
        public StatutReservation Statut
        {
            get
            {
                if (DateTime.Now.CompareTo(Debut) < 0) return StatutReservation.PREVU;
                else if (DateTime.Now.CompareTo(Fin) > 0) return StatutReservation.FINI;
                else return StatutReservation.EN_COURS;
            }
        }
        public Client? Client { get; init; }
        public HashSet<Chambre> Chambres { get; init; } = new();

        public override string ToString() => $"{Id}. Du {Debut.ToShortDateString()} au {Fin.ToShortDateString()} par {Client.NomComplet}";
    }
}