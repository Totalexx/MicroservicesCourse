using RentCore.Dal.Base;

namespace ProfileDal.Users.Models;

public record RatingDal : BaseEntityDal<Guid>
{
    public required Guid User { get; init; }
    public required Guid Rater { get; init; }
    public required int Rating { get; init; }
}