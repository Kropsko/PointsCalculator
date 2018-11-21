using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System.Linq;

namespace PointsCalculator.Domain.Application
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Configuration CreateNewConfiguration(Player player, Gameplay gamplay, Color color)
        {
            Configuration conf = new Configuration();
            conf.PlayerId = player.PlayerId;
            conf.GameplayID = gamplay.GameplayId;
            conf.Color = color;

            _unitOfWork.ConfigurationRepository.Add(conf);
            _unitOfWork.Complete();

            return conf;
        }

        public Configuration GetPlayerConfigurationForGameplay(Player player, Gameplay gamplay)
        {
            return _unitOfWork.ConfigurationRepository.Find(c => c.PlayerId == player.PlayerId && c.GameplayID == gamplay.GameplayId).FirstOrDefault();
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
