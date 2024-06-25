namespace Api.Controllers.Responses;

public record AllApartmentsInfoResponse
{
    public required List<ApartmentInfoResponse> Apartments { get; init; }
}