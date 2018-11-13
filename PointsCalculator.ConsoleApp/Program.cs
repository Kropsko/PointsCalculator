using Autofac;
using PointsCalculator.Container;
using PointsCalculator.Domain.Infrastructure;
using System;

namespace PointsCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ComponentRegistrar registrar = new ComponentRegistrar();
            var container = registrar.BuildContainer();

            var gameplayService = container.Resolve<IGameplayService>();
            var gameplay = gameplayService.StartNewGameplay();

            gameplayService.EndCurrentGemeplay(gameplay);

            Console.ReadKey();
        }
    }
}
