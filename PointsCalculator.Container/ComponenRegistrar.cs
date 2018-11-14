using Autofac;
using PointsCalculator.Domain.Application;
using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using PointsCalculator.Persistance;
using PointsCalculator.Persistance.Repositories;

namespace PointsCalculator.Container
{
    public class ComponentRegistrar
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<GameplayService>().As<IGameplayService>();
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>();
            builder.RegisterType<ActionService>().As<IActionService>();

            builder.RegisterType<GameplayRepository>().As<IGameplayRepository>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>();
            builder.RegisterType<ActionRepository>().As<IActionRepository>();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<PointsCalculatorContext>();

            return builder.Build();
        }
    }
}
