using Autofac;
using PointsCalculator.Container;
using PointsCalculator.Domain.Application;
using PointsCalculator.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
