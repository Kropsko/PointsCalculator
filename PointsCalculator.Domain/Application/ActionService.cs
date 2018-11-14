using PointsCalculator.Domain.Infrastructure;
using PointsCalculator.Domain.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCalculator.Domain.Application
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;

        public void CreateAwardPointsAction(Player player, Gameplay gameplay, int points)
        {
            Action awardPointAction = new Action();
            awardPointAction.ActionType = ActionType.AwardingPoints;
            awardPointAction.Player = player;
            awardPointAction.Gameplay = gameplay;
            awardPointAction.Points = points;

            _actionRepository.CreateNewAction(awardPointAction);
        }

        public void CreateSubstractPointsAction(Player player, Gameplay gameplay, int points)
        {
            Action substractPointAction = new Action();
            substractPointAction.ActionType = ActionType.SubstractingPoints;
            substractPointAction.Player = player;
            substractPointAction.Gameplay = gameplay;
            substractPointAction.Points = points;

            _actionRepository.CreateNewAction(substractPointAction);
        }

        public ActionService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }
    }
}
