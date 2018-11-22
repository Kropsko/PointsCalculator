using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace PointsCalculator.Domain.Application
{
    public class GameplayService : IGameplayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameplayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void EndGemeplay(Gameplay gameplay)
        {
            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            gameplay.End = DateTime.Now;
            gameplay.IsActive = false;
            gameplay.IsEnded = true;
            _unitOfWork.Complete();
        }

        public Gameplay CreateNewGameplay()
        {
            Gameplay newGameplay = new Gameplay();
            _unitOfWork.GameplayRepository.Add(newGameplay);
            _unitOfWork.Complete();

            return newGameplay;
        }

        public Gameplay GetCompleteGameplay(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Gameplay id should have positive value");

            return _unitOfWork.GameplayRepository.GetCompleteGameplayWithIncludes(id);
        }

        public void StartGameplay(Gameplay gameplay)
        {
            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            gameplay.Start = DateTime.Now;
            gameplay.IsActive = true;
            _unitOfWork.Complete();
        }

        public void SetPlayerForGameplay(Player player, Gameplay gameplay)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (player.PlayerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(player.PlayerId));

            if (gameplay == null)
                throw new ArgumentNullException(nameof(gameplay));

            if (gameplay.GameplayId <= 0)
                throw new ArgumentOutOfRangeException(nameof(gameplay.GameplayId));

            GameplayPlayer gameplayPlayer = new GameplayPlayer();
            gameplayPlayer.GameplayId = gameplay.GameplayId;
            gameplayPlayer.PlayerId = player.PlayerId;

            _unitOfWork.GameplayRepository.GetCompleteGameplayWithIncludes(gameplay.GameplayId).Players.Add(gameplayPlayer);
            _unitOfWork.Complete();
        }            
    }
}
