namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayService
    {
        Gameplay StartNewGameplay();
        void EndCurrentGemeplay(Gameplay gameplay);
    }
}
