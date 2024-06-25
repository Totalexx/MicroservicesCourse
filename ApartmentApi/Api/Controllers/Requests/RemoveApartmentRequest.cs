namespace Api.Controllers.Requests;

public class RemoveApartmentRequest
{
    public required Guid ApartmentId { get; init; }
    public required string AccessToken { get; init; }
}