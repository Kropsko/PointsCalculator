namespace PointsCalculator.Domain.Infrastructure
{
    public interface IConfigurationService
    {
        Configuration CreateNewConfiguration(Player player, Gameplay gamplay, Color color);
        Configuration GetPlayerConfigurationForGameplay(Player player, Gameplay gamplay);
        void UpdateConfiguration(Configuration configuration);
    }
}
