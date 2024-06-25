namespace Api.Controllers.Requests;

public class UpdateApartmentPriceRequest
{
    public required Guid ApartmentId { get; init; }
    public required double PricePerDay { get; init; }
    public required string AccessToken { get; init; }
}