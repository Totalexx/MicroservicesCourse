namespace Api.Controllers.Responses;

public record ApartmentInfoResponse
{
    public required string City { get; init; }
    public required string Street { get; init; }
    public required string BuildingNumber { get; init; }
    public required int ApartmentNumber { get; init; }
    public required int RoomsCount { get; init; }
    public required double PricePerDay { get; init; }
    public required Guid OwnerId { get; init; }
}