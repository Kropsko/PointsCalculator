using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure;

namespace PointsCalculator.Persistance.Repositories
{
    public class GameplayRepository : IGameplayRepository
    {
        private readonly Context _context;

        public GameplayRepository(Context context)
        {
            _context = context;
        }

        public void AddNewGameplay(Gameplay gameplay)
        {
            _context.Gameplays.Add(gameplay);
            _context.SaveChanges();
        }

        public void UpdateGameplay(Gameplay gameplay)
        {
            _context.SaveChanges();
        }
    }
}
