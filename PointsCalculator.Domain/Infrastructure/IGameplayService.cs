using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Infrastructure
{
    public interface IGameplayService
    {
        Gameplay StartNewGameplay();
        void EndCurrentGemeplay(Gameplay gameplay);
    }
}
