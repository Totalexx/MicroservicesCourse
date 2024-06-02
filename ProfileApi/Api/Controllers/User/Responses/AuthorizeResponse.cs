namespace ProfileApi.Controllers.User.Responses;

public record AuthorizeResponse
{
    public required Guid UserId { get; init; }
    public required string SessionToken { get; init; }
}