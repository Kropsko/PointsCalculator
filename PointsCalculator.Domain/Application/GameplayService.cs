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
                throw new ArgumentException("Gameplay object cannot be null.");

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
                throw new ArgumentException("Gameplay id has to be greater than zero.");

            return _unitOfWork.GameplayRepository.GetCompleteGameplayWithIncludes(id);
        }

        public void StartGameplay(Gameplay gameplay)
        {
            if (gameplay == null)
                throw new ArgumentException("Gameplay object cannot be null.");

            gameplay.Start = DateTime.Now;
            gameplay.IsActive = true;
            _unitOfWork.Complete();
        }

        public void SetPlayerForGameplay(Player player, Gameplay gameplay)
        {
            if (player == null || player.PlayerId <= 0)
                throw new ArgumentException("Player id has to be greater than zero.");

            if (gameplay == null || gameplay.GameplayId <= 0)
                throw new ArgumentException("Gameplay id has to be greater than zero.");

            GameplayPlayer gameplayPlayer = new GameplayPlayer();
            gameplayPlayer.GameplayId = gameplay.GameplayId;
            gameplayPlayer.PlayerId = player.PlayerId;

            _unitOfWork.GameplayRepository.GetCompleteGameplayWithIncludes(gameplay.GameplayId).Players.Add(gameplayPlayer);
            _unitOfWork.Complete();
        }            
    }
}
