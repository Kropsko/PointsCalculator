using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;

namespace PointsCalculator.Domain.Application
{
    public class ActionService : IActionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public void CreateAwardPointsAction(Player player, Gameplay gameplay, int points)
        {
            if (player == null || player.PlayerId <= 0)
                throw new ArgumentException("Player id has to be greater than zero.");

            if(gameplay == null || gameplay.GameplayId <= 0)
                throw new ArgumentException("Gameplay id has to be greater than zero.");

            if (points <= 0)
                throw new ArgumentException("Award points have to be greater than zero");

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
            if (player == null || player.PlayerId <= 0)
                throw new ArgumentException("Player id has to be greater than zero.");

            if (gameplay == null || gameplay.GameplayId <= 0)
                throw new ArgumentException("Gameplay id has to be greater than zero.");

            if (points <= 0)
                throw new ArgumentException("Penalty points have to be greater than zero");

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
