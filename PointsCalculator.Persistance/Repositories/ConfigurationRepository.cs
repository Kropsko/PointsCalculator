using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Persistance.Repositories
{
    public class ConfigurationRepository : Repository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(PointsCalculatorContext context) : base(context)
        {
        }

        private PointsCalculatorContext PointsCalculatorContext
        {
            get { return Context as PointsCalculatorContext; }
        }
    }
}
