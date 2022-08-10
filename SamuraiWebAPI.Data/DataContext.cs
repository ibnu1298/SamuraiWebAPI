using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Sword> Swords { get; set; }
        public DbSet<Demon> Demons { get; set; }
        public DbSet<TypeSword> TypeSwords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ElementSword> ElementSwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiDb")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>().HasMany(s => s.Swords)
                .WithMany(b => b.Elements)
                .UsingEntity<ElementSword>(bs => bs.HasOne<Sword>().WithMany(),
                bs => bs.HasOne<Element>().WithMany());
        }

    }

}


