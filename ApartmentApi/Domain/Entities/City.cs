using RentCore.Dal.Base;

namespace Domain.Entities;

public record City : BaseEntityDal<Guid>
{
    public required string Name { get; init; }
}