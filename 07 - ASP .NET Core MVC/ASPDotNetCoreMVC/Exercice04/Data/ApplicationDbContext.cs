using Exercice04.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice04.Data
{
    public class ApplicationDbContext : DbContext
    {
        //protected ApplicationDbContext() // : base() // facultatif sur le ctor sans params
        //{
        //}

        // dans le cas où le ConnectionString est extérieur au dbContext
        // il sera passé à la construction du ApplicationDbContext => besoin des options pour le configurer
        // exemple :  dans une application ASP.NET core, il est préférable d'avoir le connectionString dans appsettings.json
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        // dans le cas où on utilise OnConfiguring pour le ConnectionString
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\AspMvc;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) // changements contenus dans une migration
        {
            // Data seed
            //modelBuilder.Entity<Animal>().HasData(new Animal() { Id=1, FirstName = "Coco", Age = 3, Species = "Perroquet" }); // ne pas oublier l'id

            int lastIndex = 0;
            var animals = new List<Animal>()
            {
                new Animal() { Id=++lastIndex, FirstName = "Coco", Age = 3, Species = "Perroquet" },
                new Animal() { Id=++lastIndex, FirstName = "Pepette", Age = 5, Species = "Chien, Bouledogue" },
                new Animal() { Id=++lastIndex, FirstName = "Perry", Age = 15, Species = "Platypus" },
            };

            modelBuilder.Entity<Animal>().HasData(animals);

        }
    }
}
