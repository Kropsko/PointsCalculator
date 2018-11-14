using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Persistance.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly PointsCalculatorContext _context;

        public void AddNewConfiguration(Configuration conf)
        {
            _context.Configurations.Add(conf);
            _context.SaveChanges();
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            _context.SaveChanges();
        }

        public ConfigurationRepository(PointsCalculatorContext context)
        {
            _context = context;
        }
    }
}
