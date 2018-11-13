using System;
using System.Collections.Generic;

namespace PointsCalculator.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}
