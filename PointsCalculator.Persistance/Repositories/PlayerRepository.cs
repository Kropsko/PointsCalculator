using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(PointsCalculatorContext context) : base(context)
        {
        }

        private PointsCalculatorContext PointsCalculatorContext
        {
            get { return Context as PointsCalculatorContext; }
        }
    }
}
