namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayService
    {
        Gameplay CreateNewGameplay();
        void EndGemeplay(Gameplay gameplay);
        void StartGameplay(Gameplay gameplay);
        Gameplay GetCompleteGameplay(int id);
        void SetPlayerForGameplay(Player player, Gameplay gameplay);
    }
}
