using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;

namespace PointsCalculator.Domain.Application
{
    public class ActionService : IActionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public void CreateAwardPointsAction(Player player, Gameplay gameplay, int points)
        {
            Action awardPointAction = new Action();
            awardPointAction.ActionType = ActionType.AwardingPoints;
            awardPointAction.PlayerId = player.PlayerId;
            awardPointAction.GameplayId = gameplay.GameplayId;
            awardPointAction.Points = points;

            _unitOfWork.ActionRepository.Add(awardPointAction);
            _unitOfWork.Complete();
        }

        public void CreateSubstractPointsAction(Player player, Gameplay gameplay, int points)
        {
            Action substractPointAction = new Action();
            substractPointAction.ActionType = ActionType.SubstractingPoints;
            substractPointAction.PlayerId = player.PlayerId;
            substractPointAction.GameplayId = gameplay.GameplayId;
            substractPointAction.Points = points;

            _unitOfWork.ActionRepository.Add(substractPointAction);
            _unitOfWork.Complete();
        }

        public ActionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
