using System;
using System.Collections.Generic;

namespace PointsCalculator.Domain
{
    public class Gameplay
    {
        public int GameplayId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsActive { get; set; }
        public bool IsEnded { get; set; }
        public ICollection<GameplayPlayer> Players { get; private set; }
        public ICollection<Configuration> Configurations { get; private set; }
        public ICollection<Action> Actions { get; private set; }

        public Gameplay()
        {
            Players = new List<GameplayPlayer>();
            Configurations = new List<Configuration>();
            Actions = new List<Action>();
        }
    }
}
