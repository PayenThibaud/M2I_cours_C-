using Correction01Personnage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Personnage.Data
{
    /// <summary>
    /// Cette classe permet de faire le lien entre notre base de données et nos modèles
    /// Le context va nous permettre de faire des requêtes sur des DbSet à l'aide de LinQ
    /// On va pouvoir paramétrer la base de données utilisée ainsi que la configuration des différentes tables
    /// </summary>
    internal class ApplicationDbContext : DbContext
    {

        // Les DbSet font le lien entre nos tables en base de données et nos modèles dans le projet
        public DbSet<Personnage> Personnages { get; set; }

        /// <summary>
        /// Cette méthode nous permet de configurer le connecteur à utiliser avec EFCore
        /// On utilise le builder passé en paramètre pour configurer notre connexion à SQL Server
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=PersonnageDB");
        }
    }
}
