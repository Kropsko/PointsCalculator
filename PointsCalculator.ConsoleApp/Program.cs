using Autofac;
using PointsCalculator.Container;
using PointsCalculator.Domain;
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

            var gameplay = gameplayService.CreateNewGameplay();

            Player player = new Player();
            player.Name = "Testowy gracz";
            player.CreateDate = DateTime.Now;

            Player secondPlayer = new Player();
            secondPlayer.Name = "Kolejny gracz";
            secondPlayer.CreateDate = DateTime.Now;

            gameplay.Players.Add(player);
            gameplay.Players.Add(secondPlayer);

            Configuration conf = new Configuration();
            conf.Player = player;
            conf.Color = Color.Blue;

            Configuration secondConf = new Configuration();
            secondConf.Player = secondPlayer;
            secondConf.Color = Color.Red;

            gameplay.Configurations.Add(conf);
            gameplay.Configurations.Add(secondConf);

            gameplayService.StartGameplay(gameplay);

            Domain.Action addPoints = new Domain.Action();
            addPoints.ActionType = ActionType.AwardingPoints;
            addPoints.Gameplay = gameplay;
            addPoints.Player = player;
            addPoints.Points = 5;

            gameplay.Actions.Add(addPoints);
            gameplay.Actions.Add(addPoints);
            gameplay.Actions.Add(addPoints);

            gameplayService.EndCurrentGemeplay(gameplay);

            playerService.DeletePlayer(secondPlayer); 

            Console.ReadKey();
        }
    }
}
