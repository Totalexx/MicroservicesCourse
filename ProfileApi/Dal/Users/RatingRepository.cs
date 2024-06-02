using System.Collections.Concurrent;
using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;

namespace ProfileDal.Users;

/// <inheritdoc />
internal class RatingRepository : IRatingRepository
{
    private static readonly ConcurrentDictionary<Guid, RatingDal> Store = new();

    public async Task<Guid> AddRatingAsync(RatingDal rating)
    {
        if (rating.Id == Guid.Empty)
        {
            rating = rating with { Id = Guid.NewGuid() };
        }
        
        if (Store.TryAdd(rating.Id, rating))
        {
            return rating.Id;
        }
        
        throw new Exception("Ошибка добавления рейтинга");
    }

    public async Task<int> GetAverageRatingAsync(Guid userId)
    {
        var ratings = Store
            .Select(p => p.Value)
            .Where(r => r.User == userId)
            .ToList();

        if (ratings.Count == 0)
            return 0;
        
        return (int)Math.Round((double)ratings.Sum(r => r.Rating) / ratings.Count);
    }
}