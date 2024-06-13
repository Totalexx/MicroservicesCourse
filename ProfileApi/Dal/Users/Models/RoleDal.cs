using RentCore.Dal.Base;

namespace ProfileDal.Users.Models;

public record RoleDal : BaseEntityDal<Guid>
{
    public required string Name { get; init; }
};