namespace PointsCalculator.Domain.Infrastructure
{
    public interface IActionService
    {
        void CreateAwardPointsAction(Player player, Gameplay gameplay, int points);
        void CreateSubstractPointsAction(Player player, Gameplay gameplay, int points);
    }
}
