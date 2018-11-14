using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;

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
    }
}
