using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class GameplayRepository : IGameplayRepository
    {
        private readonly PointsCalculatorContext _context;

        public GameplayRepository(PointsCalculatorContext context)
        {
            _context = context;
        }

        public Gameplay AddNewGameplay(Gameplay gameplay)
        {
            _context.Gameplays.Add(gameplay);
            _context.SaveChanges();

            return gameplay;
        }

        public void UpdateGameplay(Gameplay gameplay)
        {
            _context.SaveChanges();
        }
    }
}
