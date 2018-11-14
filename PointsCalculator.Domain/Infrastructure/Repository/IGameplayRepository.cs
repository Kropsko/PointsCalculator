namespace PointsCalculator.Domain.Infrastructure.Repository
{
    public interface IGameplayRepository
    {
        Gameplay AddNewGameplay(Gameplay gameplay);
        void UpdateGameplay(Gameplay gameplay);
    }
}
