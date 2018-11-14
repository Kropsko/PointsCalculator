using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Infrastructure.Repository
{
    public interface IPlayerRepository
    {
        Player AddNewPlayer(Player player);
        void UpdatePlayer(Player player);
    }
}
