using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Application
{
    public class PlayerService : IPlayerService
    {
        private readonly IActionService _actionService;
        private readonly IPlayerRepository _playerRepository;


        public void AwardPoints(Player player, Gameplay gameplay, int pointsCount)
        {
            _actionService.CreateAwardPointsAction(player, gameplay, pointsCount);
        }

        public Player CreateNewplayer(Player player)
        {
            return _playerRepository.AddNewPlayer(player);
        }

        public void DeletePlayer(Player player)
        {
            player.DeleteDate = DateTime.Now;
            player.IsDeleted = true;

            _playerRepository.UpdatePlayer(player);
        }

        public void SubstractPoints(Player player, Gameplay gameplay, int pointsCount)
        {
            _actionService.CreateSubstractPointsAction(player, gameplay, pointsCount);
        }

        public PlayerService(IActionService actionService, IPlayerRepository playerRepository)
        {
            _actionService = actionService;
            _playerRepository = playerRepository;
        }
    }
}
