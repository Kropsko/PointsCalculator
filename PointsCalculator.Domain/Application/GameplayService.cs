using PointsCalculator.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Gameplay StartNewGameplay()
        {
            Gameplay newGameplay = new Gameplay();
            newGameplay.IsActive = true;

            _gameplayRepository.AddNewGameplay(newGameplay);

            return newGameplay;
        }
    }
}
