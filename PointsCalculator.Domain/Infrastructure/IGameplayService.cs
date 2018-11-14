namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayService
    {
        Gameplay CreateNewGameplay();
        void EndGemeplay(Gameplay gameplay);
        void StartGameplay(Gameplay gameplay);
    }
}
