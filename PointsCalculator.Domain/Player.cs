using System;
using System.Collections.Generic;

namespace PointsCalculator.Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<Configuration> Configurations { get; set; }
        public ICollection<GameplayPlayer> Gameplays { get; set; }

        public Player()
        {
            Actions = new List<Action>();
            Configurations = new List<Configuration>();
            Gameplays = new List<GameplayPlayer>();
        }

        public Player(string name) : this()
        {
            Name = name;
            CreateDate = DateTime.Now;
        }
    }
}
