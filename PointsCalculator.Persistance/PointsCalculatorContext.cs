using Microsoft.EntityFrameworkCore;
using PointsCalculator.Domain;

namespace PointsCalculator.Persistance
{
    public class PointsCalculatorContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Gameplay> Gameplays { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Domain.Action> Actions { get; set; }

        private static bool _created = false;
        public PointsCalculatorContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PointsCalculator.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasKey(x => x.PlayerId);
            modelBuilder.Entity<Gameplay>()
                .HasKey(x => x.GameplayId);
            modelBuilder.Entity<Action>()
                .HasKey(x => x.ActionId);
            modelBuilder.Entity<Configuration>()
                .HasKey(x => x.ConfigurationId);

            modelBuilder.Entity<GameplayPlayer>()
                .HasKey(t => new { t.GameplayId, t.PlayerId });
        }
    }
}
