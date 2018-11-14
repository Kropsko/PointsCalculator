﻿namespace PointsCalculator.Domain.Infrastructure
{
    public interface IPlayerService
    {
        Player CreateNewplayer(Player player);
        void DeletePlayer(Player player);
        void AwardPoints(Player player, Gameplay gameplay, int pointsCount);
        void SubstractPoints(Player player, Gameplay gameplay, int pointsCount);
    }
}
