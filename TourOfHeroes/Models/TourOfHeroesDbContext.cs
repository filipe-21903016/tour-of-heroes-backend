using Microsoft.EntityFrameworkCore;

namespace TourOfHeroes.Models
{
    public class TourOfHeroesDbContext: DbContext
    {
        public TourOfHeroesDbContext(DbContextOptions<TourOfHeroesDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
