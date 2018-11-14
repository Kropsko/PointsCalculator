using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;

namespace PointsCalculator.Domain.Application
{
    public class GameplayService : IGameplayService
    {
        private readonly IGameplayRepository _gameplayRepository;

        public GameplayService(IGameplayRepository gameplayRepository)
        {
            _gameplayRepository = gameplayRepository;
        }

        public void EndCurrentGemeplay(Gameplay gameplay)
        {
            gameplay.End = DateTime.Now;
            gameplay.IsActive = false;
            gameplay.IsEnded = true;

            _gameplayRepository.UpdateGameplay(gameplay);
        }

        public Gameplay CreateNewGameplay()
        {
            Gameplay newGameplay = new Gameplay();
            _gameplayRepository.AddNewGameplay(newGameplay);

            return newGameplay;
        }

        public void StartGameplay(Gameplay gameplay)
        {
            gameplay.Start = DateTime.Now;
            gameplay.IsActive = true;
            _gameplayRepository.AddNewGameplay(gameplay);
        }
    }
}
