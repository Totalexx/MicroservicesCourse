namespace ProfileLogic.Users.Models;

public class RatingLogic
{
    public required Guid User { get; init; }
    public required Guid Rater { get; init; }
    public required int Rating { get; init; }
}