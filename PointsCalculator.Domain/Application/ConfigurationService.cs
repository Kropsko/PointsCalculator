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
            if (player == null || player.PlayerId <= 0)
                throw new ArgumentException("Player id has to be greater than zero.");

            if (gameplay == null || gameplay.GameplayId <= 0)
                throw new ArgumentException("Gameplay id has to be greater than zero.");

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
            if (player == null || player.PlayerId <= 0)
                throw new ArgumentException("Player id has to be greater than zero.");

            if (gameplay == null || gameplay.GameplayId <= 0)
                throw new ArgumentException("Gameplay id has to be greater than zero.");

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
