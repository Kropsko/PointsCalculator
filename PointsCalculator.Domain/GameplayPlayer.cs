namespace PointsCalculator.Domain
{
    public class GameplayPlayer
    {
        public int GameplayId { get; set; }
        public Gameplay Gameplay { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
