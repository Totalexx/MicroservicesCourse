using ProfileLogic.Users.Models;

namespace ProfileLogic.Users.Interfaces;

public interface IRatingLogicManager
{
    Task AddRating(RatingLogic rating);
    Task<int> GetAverageRating(Guid userId);
}

