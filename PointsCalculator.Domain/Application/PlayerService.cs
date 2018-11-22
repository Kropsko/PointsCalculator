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

        public void AwardPoints(Player player, Gameplay gameplay, int points)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Points should have positive value");

            _actionService.CreateAwardPointsAction(player, gameplay, points);
        }

        public Player CreateNewPlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(name), "Player's name has to be at least 1 character");

            Player player = new Player(name);
            player.CreateDate = DateTime.Now;

            _unitOfWork.PlayerRepository.Add(player);
            _unitOfWork.Complete();

            return player;
        }

        public void UpdatePlayerName(Player player, string name)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(name), "Player's name has to be at least 1 character");

            player.Name = name;
            _unitOfWork.Complete();
        }

        public void DeletePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            player.DeleteDate = DateTime.Now;
            player.IsDeleted = true;

            _unitOfWork.Complete();
        }

        public void SubstractPoints(Player player, Gameplay gameplay, int points)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Points should have positive value");

            _actionService.CreateSubstractPointsAction(player, gameplay, points);
        }

        public int GetPlayerScoreForGameplay(Player player, Gameplay gameplay)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            var actions = _unitOfWork.ActionRepository.Find(a => a.PlayerId == player.PlayerId && a.GameplayId == gameplay.GameplayId).ToList();

            int points = actions.Where(x => x.ActionType == ActionType.AwardingPoints).Sum(x => x.Points);
            int penalty = actions.Where(x => x.ActionType == ActionType.SubstractingPoints).Sum(x => x.Points);

            return points - penalty;
        }

        public IEnumerable<Player> GetAllAvailablePlayers()
        {
            return _unitOfWork.PlayerRepository.Find(p => p.IsDeleted == false);
        }

        public Player GetPlayer(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Player id should have positive value");

            return _unitOfWork.PlayerRepository.Get(id);
        }

        public PlayerService(IActionService actionService, IUnitOfWork unitOfWork)
        {
            _actionService = actionService;
            _unitOfWork = unitOfWork;
        }
    }
}
