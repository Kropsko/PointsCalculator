using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Domain.Application
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public void CreateNewConfiguration(Player player, Gameplay gamplay, Color color)
        {
            Configuration conf = new Configuration();
            conf.Player = player;
            conf.Gameplay = gamplay;
            conf.Color = color;

            _unitOfWork.ConfigurationRepository.Add(conf);
            _unitOfWork.Complete();
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            _unitOfWork.Complete();
        }

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
