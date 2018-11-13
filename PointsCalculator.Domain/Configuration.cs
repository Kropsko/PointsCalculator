namespace PointsCalculator.Domain
{
    public class Configuration
    {
        public int Id { get; set; }
        public int GameplayID { get; set; }
        public int PlayerId { get; set; }
        public Color Color { get; set; }
        public Gameplay Gameplay { get; set; }
        public Player Player { get; set; }

        public Configuration()
        {
        }
    }
}
