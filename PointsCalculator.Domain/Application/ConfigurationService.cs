using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Application
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public void CreateNewConfiguration(Player player, Gameplay gamplay, Color color)
        {
            Configuration conf = new Configuration();
            conf.Player = player;
            conf.Gameplay = gamplay;
            conf.Color = color;

            _configurationRepository.AddNewConfiguration(conf);
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            _configurationRepository.UpdateConfiguration(configuration);
        }

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }
    }
}
