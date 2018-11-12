using PointsCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
