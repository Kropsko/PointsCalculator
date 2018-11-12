using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayRepository
    {
        void AddNewGameplay(Gameplay gameplay);
        void UpdateGameplay(Gameplay gameplay);
    }
}
