using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileLogic.Users;

internal class RatingLogicManager : IRatingLogicManager
{
    private readonly IRatingRepository _ratingRepository;

    public RatingLogicManager(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task AddRating(RatingLogic rating)
    {
        await _ratingRepository.AddRatingAsync(new RatingDal
        {
            User = rating.User,
            Rater = rating.Rater,
            Rating = rating.Rating
        });
    }

    public async Task<int> GetAverageRating(Guid userId)
    {
        return await _ratingRepository.GetAverageRatingAsync(userId);
    }
}