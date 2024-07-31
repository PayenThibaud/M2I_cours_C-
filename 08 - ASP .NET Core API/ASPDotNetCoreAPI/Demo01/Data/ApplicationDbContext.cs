using Demo01.Helpers;
using Demo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<Crepe> Crepes { get; set; }
#nullable enable

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crepe>().HasData(InitialData.Crepes);
        }
    }
}
