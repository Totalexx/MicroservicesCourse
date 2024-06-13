using RentCore.Dal.Base;

namespace ProfileDal.Users.Models;

public record SessionDal : BaseEntityDal<Guid>
{
    public required Guid UserId { get; init; }
    public required string SessionToken { get; init; }
}