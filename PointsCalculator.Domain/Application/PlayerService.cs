using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsCalculator.Domain.Application
{
    public class PlayerService : IPlayerService
    {
        private readonly IActionService _actionService;
        private readonly IUnitOfWork _unitOfWork;

        public void AwardPoints(Player player, Gameplay gameplay, int pointsCount)
        {
            _actionService.CreateAwardPointsAction(player, gameplay, pointsCount);
        }

        public Player CreateNewPlayer(string name)
        {
            Player player = new Player(name);     

            _unitOfWork.PlayerRepository.Add(player);
            _unitOfWork.Complete();

            return player;
        }

        public void UpdatePlayerName(Player player, string name)
        {
            player.Name = name;
            _unitOfWork.Complete();
        }

        public void DeletePlayer(Player player)
        {
            player.DeleteDate = DateTime.Now;
            player.IsDeleted = true;

            _unitOfWork.Complete();
        }

        public void SubstractPoints(Player player, Gameplay gameplay, int pointsCount)
        {
            _actionService.CreateSubstractPointsAction(player, gameplay, pointsCount);
        }

        public int GetPlayerScoreForGameplay(Player player, Gameplay gameplay)
        {
            var actions = _unitOfWork.ActionRepository.Find(a => a.PlayerId == player.Id && a.GameplayId == gameplay.Id);

            int points = actions.Where(x => x.ActionType == ActionType.AwardingPoints).Sum(x => x.Points);
            int penalty = actions.Where(x => x.ActionType == ActionType.SubstractingPoints).Sum(x => x.Points);

            return points - penalty;
        }

        public IEnumerable<Player> GetAllAvailablePlayers()
        {
            return _unitOfWork.PlayerRepository.Find(p => p.IsDeleted == false);
        }

        public PlayerService(IActionService actionService, IUnitOfWork unitOfWork)
        {
            _actionService = actionService;
            _unitOfWork = unitOfWork;
        }
    }
}
