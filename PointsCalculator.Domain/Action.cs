﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain
{
    public class Action
    {
        public int Id { get; set; }
        public int GameplayId { get; set; }
        public int PlayerId { get; set; }
        public ActionType ActionType { get; set; }
        public int Points { get; set; }
        public Gameplay Gameplay { get; set; }
        public Player Player { get; set; }
    }
}
