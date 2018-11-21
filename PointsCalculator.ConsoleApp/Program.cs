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
            var playerService = container.Resolve<IPlayerService>();
            var configurationService = container.Resolve<IConfigurationService>();
            var actionService = container.Resolve<IActionService>();

            var gameplay = gameplayService.GetCompleteGameplay(1); //gameplayService.CreateNewGameplay();

            //var playerOne = playerService.CreateNewPlayer("Gracz 1");
            var playerOne = playerService.GetPlayer(1);
            //var playerTwo = playerService.CreateNewPlayer("Gracz 2");
            var playerTwo = playerService.GetPlayer(2);
            //var playerThree = playerService.CreateNewPlayer("Gracz 3");
            var playerThree = playerService.GetPlayer(3);

            //gameplayService.SetPlayerForGameplay(playerOne, gameplay);
            //gameplayService.SetPlayerForGameplay(playerTwo, gameplay);

            //configurationService.CreateNewConfiguration(playerOne, gameplay, Color.Red);
            //configurationService.CreateNewConfiguration(playerTwo, gameplay, Color.Black);

            //gameplayService.StartGameplay(gameplay);

            //playerService.AwardPoints(playerOne, gameplay, 10);
            //playerService.AwardPoints(playerOne, gameplay, 5);
            //playerService.AwardPoints(playerOne, gameplay, 2);
            //playerService.SubstractPoints(playerOne, gameplay, 5);
            //playerService.AwardPoints(playerTwo, gameplay, 1);
            //playerService.AwardPoints(playerTwo, gameplay, 2);
            //playerService.AwardPoints(playerTwo, gameplay, 3);

            //gameplayService.EndGemeplay(gameplay);

            //playerService.DeletePlayer(playerThree);

            foreach (var player in gameplay.Players)
            {
                Console.WriteLine($"Player: {player.Player.Name} has {playerService.GetPlayerScoreForGameplay(player.Player, gameplay)} points.");
            }

            Console.ReadKey();
        }
    }
}
