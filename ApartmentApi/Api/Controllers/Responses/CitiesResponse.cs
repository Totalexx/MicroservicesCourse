namespace Api.Controllers.Responses;

public record CitiesResponse
{
    public required List<string> Cities { get; init; }
}