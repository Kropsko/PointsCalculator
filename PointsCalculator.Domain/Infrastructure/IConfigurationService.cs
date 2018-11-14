namespace PointsCalculator.Domain.Infrastructure
{
    public interface IConfigurationService
    {
        void CreateNewConfiguration(Player player, Gameplay gamplay, Color color);
        void UpdateConfiguration(Configuration configuration);
    }
}
