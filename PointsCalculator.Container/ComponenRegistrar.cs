using Autofac;
using PointsCalculator.Domain.Application;
using PointsCalculator.Domain.Infrastructure;
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
            builder.RegisterType<GameplayRepository>().As<IGameplayRepository>();
            builder.RegisterType<Context>();

            return builder.Build();
        }
    }
}
