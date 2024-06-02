namespace ProfileApi.Controllers.Rating.Responses;

public record RatingResponse
{
    public required Guid User { get; init; }
    public required int Rating { get; init; }
}