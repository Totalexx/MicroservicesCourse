using RentCore.Dal.Base;

namespace Domain.Entities;

public record Apartment : BaseEntityDal<Guid>
{
    public required Address Address { get; init; }
    public required int RoomsCount { get; init; }
    public required double PricePerDay { get; init; }
    public required Guid OwnerId { get; init; }
}