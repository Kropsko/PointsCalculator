using System.Collections.Generic;

namespace PointsCalculator.Domain.Infrastructure
{
    public interface IPlayerService
    {
        Player CreateNewPlayer(string name);
        Player GetPlayer(int id);
        void DeletePlayer(Player player);
        void AwardPoints(Player player, Gameplay gameplay, int points);
        void SubstractPoints(Player player, Gameplay gameplay, int points);
        int GetPlayerScoreForGameplay(Player player, Gameplay gameplay);
        void UpdatePlayerName(Player player, string name);
        IEnumerable<Player> GetAllAvailablePlayers();
    }
}
