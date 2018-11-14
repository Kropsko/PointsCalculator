using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PointsCalculatorContext _context;

        public IActionRepository ActionRepository { get; private set; }

        public IConfigurationRepository ConfigurationRepository { get; private set; }

        public IGameplayRepository GameplayRepository { get; private set; }

        public IPlayerRepository PlayerRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public UnitOfWork(PointsCalculatorContext context)
        {
            _context = context;
            ActionRepository = new ActionRepository(_context);
            ConfigurationRepository = new ConfigurationRepository(_context);
            GameplayRepository = new GameplayRepository(_context);
            PlayerRepository = new PlayerRepository(_context);
        }
    }
}
