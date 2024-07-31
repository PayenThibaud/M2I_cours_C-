using Demo02Relations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Data
{
    internal class ApplicationDbContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=DemoBlog;");
        }

        // S'exécute lors de la création des tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.TagId, pt.PostId });

            // HasData permet d'ajouter des données dans la base lors de la création des tables
            modelBuilder.Entity<Blog>().HasData(
                new Blog() { Id = 1, Nom = "JohnnyHalliday115", Url = "http://www.johnnyhalliday115.skyblog.com" },
                new Blog() { Id = 2, Nom = "Koreus", Url = "http://www.koreus.com" },
                new Blog() { Id = 3, Nom = "Toto", Url = "http://www.toto.com" });

            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, Titre = "Johnny est mort.", BlogId = 1, Contenu = "Trop triste :'(" },
                new Post() { Id = 2, Titre = "Trop mdr xd la vidéo OLALALA", BlogId = 2, Contenu = "Le chat il tombe là" },
                new Post() { Id = 3, Titre = "Tu connais la blague de toto aux toilettes ?", BlogId = 3, Contenu = "Moi non plus la porte était fermée ^^" }
                );
        }


    }
}
