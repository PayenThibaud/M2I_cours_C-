using Correction02Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Hotel.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationChambre> ReservationChambres { get; set; }
        public DbSet<Chambre> Chambres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Database=Correction02Hotel;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // l'instruction suivante sert à créer une clé primaire composite
            // elle est composé de plusieurs colonnes (ici une paire de colonne)
            // cela est utile pour dire qu'une Réservation ne peut être associée à une chambre qu'une seule fois 
            // exemple : on ne pourra pas avoir plusieurs fois l'entrée (chambre n°1, réservation n°2)
            modelBuilder.Entity<ReservationChambre>()
                .HasKey(rc => new { rc.ChambreNumero, rc.ReservationId });


            // DATA SEED

            modelBuilder.Entity<Chambre>().HasData(new Chambre()
            {
                Numero = 1,
                NombreLits = 2,
                Statut = StatutChambre.Libre,
                Tarif = 100.50M
            },
            new Chambre()
            {
                Numero = 2,
                NombreLits = 4,
                Statut = StatutChambre.Nettoyage,
                Tarif = 400.50M
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Identifiant = 1,
                Prenom = "Guillaume",
                Nom = "Mairesse",
                Telephone = "0607080910"
            },
            new Client()
            {
                Identifiant = 2,
                Prenom = "Antoine",
                Nom = "Dieudonné",
                Telephone = "0607080911"
            });
        }
    }
}
