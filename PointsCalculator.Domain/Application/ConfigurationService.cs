using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Linq;

namespace PointsCalculator.Domain.Application
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Configuration CreateNewConfiguration(Player player, Gameplay gameplay, Color color)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            Configuration conf = new Configuration();
            conf.PlayerId = player.PlayerId;
            conf.GameplayID = gameplay.GameplayId;
            conf.Color = color;

            _unitOfWork.ConfigurationRepository.Add(conf);
            _unitOfWork.Complete();

            return conf;
        }

        public Configuration GetPlayerConfigurationForGameplay(Player player, Gameplay gameplay)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            return _unitOfWork.ConfigurationRepository.Find(c => c.PlayerId == player.PlayerId && c.GameplayID == gameplay.GameplayId).FirstOrDefault();
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
