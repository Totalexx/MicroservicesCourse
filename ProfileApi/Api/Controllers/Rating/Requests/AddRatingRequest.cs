namespace ProfileApi.Controllers.Rating.Requests;

public record AddRatingRequest
{
    public required Guid User { get; init; }
    public required Guid Rater { get; init; }
    public required int Rating { get; init; }
}