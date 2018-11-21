namespace PointsCalculator.Domain.Infrastructure.Repository
{
    public interface IGameplayRepository : IRepository<Gameplay>
    {
        Gameplay GetCompleteGameplayWithIncludes(int id);
    }
}
