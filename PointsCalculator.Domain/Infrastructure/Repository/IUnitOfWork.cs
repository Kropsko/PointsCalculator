using System;

namespace PointsCalculator.Domain.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IActionRepository ActionRepository { get; }
        IConfigurationRepository ConfigurationRepository { get; }
        IGameplayRepository GameplayRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        int Complete();
    }
}
