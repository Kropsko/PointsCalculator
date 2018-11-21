using Microsoft.EntityFrameworkCore;
using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;
using System.Linq;

namespace PointsCalculator.Persistance.Repositories
{
    public class GameplayRepository : Repository<Gameplay>, IGameplayRepository
    {
        public GameplayRepository(PointsCalculatorContext context) : base(context)
        {
        }

        private PointsCalculatorContext PointsCalculatorContext
        {
            get { return Context as PointsCalculatorContext; }
        }

        public Gameplay GetCompleteGameplayWithIncludes(int id)
        {
            return Context.Set<Gameplay>()
                .Include(g => g.Configurations)                
                .Include(g => g.Players)
                    .ThenInclude(c => c.Player)
                .Include(g => g.Actions).Where(g => g.GameplayId == id).SingleOrDefault();
        }
    }
}
