using ContactApiDTO.Models;
using ContactApiDTOAsync.Helpers; 
using ContactApiDTOAsync.Models; 
using Microsoft.EntityFrameworkCore; 


namespace ContactApiDTO.Data
{
    
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Désactivation temporaire des avertissements sur les propriétés pouvant être nulles
#nullable disable
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        // Surcharge de la méthode OnModelCreating pour configurer le modèle de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Création d'un utilisateur admin par défaut dans la base de données
            var adminRoot = new User()
            {
                Id = 1, 
                FirstName = "Root", 
                LastName = "ROOT", 
                BirthDate = new DateTime(2000, 1, 1), 
                Gender = "X", // Genre
                IsAdmin = true, // Statut d'administrateur
                Email = "root@utopios.com", // Email
                // Cryptage du mot de passe avec une clé spécifique
                Password = PasswordCrypter.Encrypt("PAss00++", "Des paillettes dans mes yeux Kevin")
            };
            // Ajout de l'utilisateur admin au modèle pour qu'il soit créé dans la base de données
            modelBuilder.Entity<User>().HasData(adminRoot);
        }
    }
}
