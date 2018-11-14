using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class ActionRepository : IActionRepository
    {
        private readonly PointsCalculatorContext _context;

        public void CreateNewAction(Domain.Action awardPointAction)
        {
            _context.Actions.Add(awardPointAction);
            _context.SaveChanges();
        }

        public ActionRepository(PointsCalculatorContext context)
        {
            _context = context;
        }
    }
}
