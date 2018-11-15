namespace PointsCalculator.Domain.Infrastructure
{
    public interface IPlayerService
    {
        Player CreateNewPlayer(string name);
        void DeletePlayer(Player player);
        void AwardPoints(Player player, Gameplay gameplay, int pointsCount);
        void SubstractPoints(Player player, Gameplay gameplay, int pointsCount);
        int GetPlayerScoreForGameplay(Player player, Gameplay gameplay);
    }
}
