using System;
using System.Collections.Generic;

namespace PointsCalculator.Domain
{
    public class Gameplay
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnded { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Configuration> Configurations { get; set; }
        public IEnumerable<Action> Actions { get; set; }

        public Gameplay()
        {
            Start = DateTime.Now;
        }
    }
}
