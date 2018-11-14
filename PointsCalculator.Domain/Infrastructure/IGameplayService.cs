namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayService
    {
        Gameplay CreateNewGameplay();
        void EndCurrentGemeplay(Gameplay gameplay);
        void StartGameplay(Gameplay gameplay);
    }
}
