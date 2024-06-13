namespace Api.Controllers.Requests;

public record FilteredApartmentsInfoRequest
{
    public string City { get; init; }
    public int MinRoomsCount { get; init; }
    public double MaxPricePerDay { get; init; }
}