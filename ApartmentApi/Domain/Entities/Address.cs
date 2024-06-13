using RentCore.Dal.Base;

namespace Domain.Entities;

public record Address : BaseEntityDal<Guid>
{
    public required Apartment Apartment { get; init; }
    public required City City { get; init; }
    public required string Street { get; init; }
    public required string BuildingNumber { get; init; }
    public required int ApartmentNumber { get; init; }
}