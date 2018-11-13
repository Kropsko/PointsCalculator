using PointsCalculator.Domain;
using System.Data.Entity;

namespace PointsCalculator.Persistance
{
    public class Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Gameplay> Gameplays { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Domain.Action> Actions { get; set; }

        public Context() : base("name=ApplicationConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
