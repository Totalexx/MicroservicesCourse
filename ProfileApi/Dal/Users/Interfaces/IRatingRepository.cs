using ProfileDal.Users.Models;

namespace ProfileDal.Users.Interfaces;

public interface IRatingRepository
{
    Task<Guid> AddRatingAsync(RatingDal rating);
    Task<int> GetAverageRatingAsync(Guid userId);
}


