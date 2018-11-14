using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class ActionRepository : Repository<Action>, IActionRepository
    {
        public ActionRepository(PointsCalculatorContext context) : base(context)
        {
        }

        private PointsCalculatorContext PointsCalculatorContext
        {
            get { return Context as PointsCalculatorContext; }
        }
    }
}
