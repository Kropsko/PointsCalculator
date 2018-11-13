namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayRepository
    {
        void AddNewGameplay(Gameplay gameplay);
        void UpdateGameplay(Gameplay gameplay);
    }
}
