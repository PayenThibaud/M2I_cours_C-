using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01Decouverte.Data
{
    // Le DbContext nous permet de communiquer entre nos modèles et la base de données
    internal class DecouverteDbContext : DbContext
    {
        // Dans une app qui n'utilise pas d'injection de dépendances, on utilisera ce constructeur
        public DecouverteDbContext() : base()
        {
        }

        public DbSet<Livre> Livres { get; set; }

        // Méthode appelée lors de la configuration d'EFCore à notre application
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ici on utilise une méthode de optionsBuilder pour lui spécifier que nous allons utiliser une base de données SqlServer
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=Demo01EFCore;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livre>().HasData(new Livre() { Id = 1, Titre = "La recette des crêpes", Auteur = "Arthur DENNETIERE", DatePublication = DateTime.Now, Description = "La meilleure recette de crêpe connue à ce jour" });
        }
    }
}
