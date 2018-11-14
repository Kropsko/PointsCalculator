using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;

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

        public void StartGameplay(Gameplay gameplay)
        {
            gameplay.Start = DateTime.Now;
            gameplay.IsActive = true;
            _unitOfWork.Complete();
        }
    }
}
