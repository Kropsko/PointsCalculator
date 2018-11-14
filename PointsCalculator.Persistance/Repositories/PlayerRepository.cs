using PointsCalculator.Domain;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Persistance.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PointsCalculatorContext _context;

        public Player AddNewPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();

            return player;
        }

        public void UpdatePlayer(Player player)
        {
            _context.SaveChanges();
        }

        public PlayerRepository(PointsCalculatorContext context)
        {
            _context = context;
        }
    }
}
